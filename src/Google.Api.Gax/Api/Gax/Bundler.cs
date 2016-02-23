/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax
{
    // Threading rules for this class:
    // - All mutable state must only ever be read or modified while holding the lock.
    // - Any mutable data provided callers must be cloned if it is stored for later use.
    // - No genuinely-user code to be executed while holding the lock. In particular:
    //   - TaskCompletionSource.TrySet{...} must not be called; continuations may execute synchronously
    //   - CancellationToken.Register can be used, but only if the action it specifies executes no user code,
    //     as again, this could be executed synchronously (if the cancellation token is already cancelled)
    //   - The ApiCallback delegate which normally calls directly to GRPC code should not be executed while
    //     holding the lock, as for testing purposes (in application code) this could end up being faked.
    //     We don't want to end up causing surprises and deadlocks.
    //   - Exceptions to the above:
    //     - The BundleComposer can contain user code, but we *expect* that to be constructed by generated code.
    //       Anyone constructing a BundleComposer manually and explicitly doing weird stuff there could no
    //       doubt do harmful things elsewhere anyway.
    // - It *is* reasonable to call the ApiCallable delegate on the thread which receives the original request (e.g.
    //   if we detect that that request has triggered the bundle conditions). This has to be reasonable, because if
    //   the bundler were not involved, the call would have gone straight to the ApiCallable.
    // - Nothing in this class should capture the context of the calling thread; any timers etc must fire on thread-pool
    //   threads instead. (If the *caller* wants continuations to occur in their context, they will just await the
    //   returned task.)

    // High level additional features to come:
    // - Flushing of all pending requests
    // - Cancellation of all in-flight (and pending) requests

    /// <summary>
    /// Provides support for bundling requests together, e.g. to combine several
    /// log entries into a single request.
    /// </summary>
    public sealed class Bundler<TRequest, TResponse>
            where TRequest : class, IMessage<TRequest>
            where TResponse : class, IMessage<TResponse>
    {
        // Immutable state
        private readonly object _monitor = new object();
        private readonly BundleSettings _settings;
        private readonly ApiCallable<TRequest, TResponse> _callable;
        private readonly BundleComposer<TRequest, TResponse> _composer;

        // Mutable state, all protected by "monitor".

        // These are bundles which are not yet in flight.
        private readonly Dictionary<TRequest, Bundle> waitingBundles;
        // These are bundles which are in flight - we may want to wait for them all to complete,
        // or cancel them all, etc.
        private readonly LinkedList<Bundle> inFlightBundles;

        /// <summary>
        /// Used for testing, primarily: checks whether the current thread owns the monitor (lock)
        /// which protects mutable state.
        /// </summary>
        internal bool InsideLock() => Monitor.IsEntered(_monitor);

        public Bundler(
            BundleSettings settings,
            BundleComposer<TRequest, TResponse> composer,
            ApiCallable<TRequest, TResponse> callable)
        {
            // TODO: Validation
            _settings = GaxPreconditions.CheckNotNull(settings, nameof(settings)).Clone();
            _settings.Validate(nameof(settings));
            this._composer = GaxPreconditions.CheckNotNull(composer, nameof(composer));
            this._callable = GaxPreconditions.CheckNotNull(callable, nameof(callable));
            waitingBundles = new Dictionary<TRequest, Bundle>(composer.RequestComparer);
            inFlightBundles = new LinkedList<Bundle>();
        }

        public Task<TResponse> Call(TRequest request, CancellationToken cancellationToken)
        {
            GaxPreconditions.CheckNotNull(request, nameof(request));
            // We never need to worry about anything else modifying the request after this.
            request = request.Clone();
            bool sendImmediately;
            bool newBundle;
            Bundle bundle;
            var clientRequest = new ClientCall(request);
            var responseTask = clientRequest.ResponseCompletionSource.Task;
            lock (_monitor)
            {
                // Needs to be in the lock as it modifies collection state
                newBundle = !waitingBundles.TryGetValue(request, out bundle);
                if (newBundle)
                {
                    bundle = new Bundle(clientRequest);
                    waitingBundles[request] = bundle;
                }
                else
                {
                    _composer.AddRequestEntries(bundle.CombinedRequest, request);
                    bundle.ClientCalls.Add(clientRequest);
                }

                // Needs to be in the lock as it reads bundle state
                sendImmediately =
                    (_settings.EntryCountThreshold != null && _composer.GetEntryCount(bundle.CombinedRequest) >= _settings.EntryCountThreshold) ||
                    (_settings.RequestSizeThreshold != null && bundle.CombinedRequest.CalculateSize() >= _settings.RequestSizeThreshold);
            }

            if (cancellationToken.CanBeCanceled)
            {
                // Note: If the token is already cancelled, this will run the handler synchronously.
                // That's fine... it just means the returned task will already be cancelled. (There can't
                // be any continuations scheduled on the task yet, as we haven't returned it to the caller...)
                // Unfortunately this is later than the check for sendImmediately, but at least if it's the *only*
                // request (but would trigger the send, e.g. due to being big) we'll notice it's cancelled and not
                // send it.
                cancellationToken.Register(CreateRequestCancellationHandler(bundle, clientRequest),
                    false); // Don't capture the synchronization context
            }
            if (sendImmediately)
            {
                TrySendBundle(bundle);
            }
            else if (_settings.DelayThreshold != null && newBundle)
            {
                // TODO: There may be a cleaner way of effectively scheduling an action...
                Task.Run(async () =>
                {
                    await Task.Delay(_settings.DelayThreshold.Value).ConfigureAwait(false);
                    TrySendBundle(bundle);
                });
            }
            return responseTask;
        }

        private Action CreateRequestCancellationHandler(Bundle bundle, ClientCall clientCall)
        {
            return () =>
            {
                Debug.Assert(!Monitor.IsEntered(_monitor));
                // All this code needs to be in a monitor, as it is modifying either the collection state
                // or the bundle state. All code here is either regular collection code or composer code
                // which is trusted to execute while the monitor is held.
                lock (_monitor)
                {
                    // Note: once the bundle is in-flight, we mustn't remove the original call... it would
                    // mess up response demultiplexing. We don't even record that the task was canceled...
                    // we'll just get the result as normal.
                    if (bundle.State != State.Waiting)
                    {
                        return;
                    }
                    bundle.ClientCalls.Remove(clientCall);
                    // If this was the only request in the bundle, drop it entirely.
                    if (bundle.ClientCalls.Count == 0)
                    {
                        bundle.State = State.Cancelled;
                        waitingBundles.Remove(bundle.CombinedRequest);
                    }
                    else
                    {
                        // Otherwise, rebuild the combined request from the remaining requests.
                        var combinedRequest = bundle.CombinedRequest;
                        _composer.ClearEntries(combinedRequest);
                        foreach (var remainingRequest in bundle.ClientCalls)
                        {
                            _composer.AddRequestEntries(combinedRequest, remainingRequest.Request);
                        }
                    }
                }
                // This must *not* be executed within the monitor.
                clientCall.ResponseCompletionSource.TrySetCanceled();
            };
        }

        private void TrySendBundle(Bundle bundle)
        {
            Debug.Assert(!Monitor.IsEntered(_monitor));
            TRequest request;
            CancellationToken token;

            // We need to be in the lock as we're moving the bundle from one collection to another,
            // and modifying its state.
            lock (_monitor)
            {
                // We may have been scheduled due to a delay threshold, but sent for
                // another reason... or there could have been multiple requests come in close to
                // simultaneously, with more than one of them deciding that we need to be sent
                // immediately.
                if (bundle.State != State.Waiting)
                {
                    return;
                }
                // The assumption is that the partitioner will identify the bundle we're sending,
                // when presented with the request we're going to send.
                waitingBundles.Remove(bundle.CombinedRequest);
                inFlightBundles.AddLast(bundle);
                bundle.State = State.InFlight;
                request = bundle.CombinedRequest;
                token = bundle.CancellationTokenSource.Token;
            }
            // We must *not* own the lock when making the underlying call.
            var task = _callable(request, token);
            task.ContinueWith(HandleResponse,
                bundle,
                CancellationToken.None, // If we need to cancel, we can use the original cancellation token source. 
                TaskContinuationOptions.DenyChildAttach, // TODO: Do we need this?
                TaskScheduler.Default); // Execute on the thread-pool. Need to check this occurs even if task is already completed.
        }

        /// <summary>
        /// Handles the response to a sent bundle.
        /// </summary>
        private void HandleResponse(Task<TResponse> task, object bundleObject)
        {
            Bundle bundle = (Bundle) bundleObject;

            // The only thing we need to do in the lock is remove the in-flight bundle from the list
            // and read/write bundle state. The 
            // This method is the only code that removes the bundle from the list, and it will happen exactly once per
            // in-flight bundle.
            IList<ClientCall> clientCalls;
            lock (_monitor)
            {
                bundle.State = State.Complete;
                inFlightBundles.Remove(bundle);
                clientCalls = bundle.ClientCalls;
            }

            // Note the use of TrySet(Status) in all cases here; the individual tasks may already have been canceled.
            // TODO: Check what happens if the continuations on some tasks throw exceptions...
            switch (task.Status)
            {
                case TaskStatus.Canceled:
                    foreach (var bundleRequest in clientCalls)
                    {
                        bundleRequest.ResponseCompletionSource.TrySetCanceled();
                    }
                    break;
                case TaskStatus.Faulted:
                    foreach (var bundleRequest in clientCalls)
                    {
                        bundleRequest.ResponseCompletionSource.TrySetException(task.Exception);
                    }
                    break;
                case TaskStatus.RanToCompletion:
                    var responses = _composer.SplitResponse(clientCalls.Select(x => x.Request).ToList(), task.Result);
                    for (int i = 0; i < responses.Count; i++)
                    {
                        clientCalls[i].ResponseCompletionSource.TrySetResult(responses[i]);
                    } 
                    break;
                default:
                    throw new InvalidOperationException($"Unexpected completion status: {task.Status}");
            }
        }

        /// <summary>
        /// Information about an original client call: a clone of the original request, and the
        /// task completion source used to communicate the response back to the caller. This is effectively
        /// immutable: although the request type itself will be mutable, the instance referenced here will never
        /// be mutated.
        /// </summary>
        private class ClientCall
        {
            internal TRequest Request { get; }
            internal TaskCompletionSource<TResponse> ResponseCompletionSource { get; } = new TaskCompletionSource<TResponse>();

            internal ClientCall(TRequest request)
            {
                Request = request;
            }
        }
        
        /// <summary>
        /// A set of possible states of a bundle.
        /// </summary>
        private enum State
        {
            // The bundle has been created, but not yet sent.
            // Every bundle in the waitingBundles collection is in this state.
            Waiting,
            // The bundle was cancelled before being sent, as all its constituent
            // requests were cancelled. This is a terminal state.
            Cancelled,
            // The bundle has been sent, but a response has not been received.
            // Every bundle in the inFlightBundles collection is in this state.
            InFlight,
            // The bundle was sent, and a response was received. (This could be
            // a fault, cancellation, or a success response.) This is a terminal state.
            Complete
        }

        /// <summary>
        /// A bundle of related requests which may be sent together. This is a mutable class in terms
        /// of:
        /// - the collection of client calls being mutated (but only before the bundle is sent)
        /// - the combined request being mutated
        /// - the state being changed
        /// </summary> 
        private sealed class Bundle
        {
            internal IList<ClientCall> ClientCalls { get; } = new List<ClientCall>();
            internal TRequest CombinedRequest { get; }
            internal State State { get; set; }
            
            // The cancellation token source used to create the token for the underlying call,
            // so we can potentially cancel requests later.
            // TODO: Use this... and work out whether we need to keep hold of the task as well,
            // for some reason.
            internal CancellationTokenSource CancellationTokenSource { get; }

            internal Bundle(ClientCall initialCall)
            {
                CombinedRequest = initialCall.Request.Clone();
                ClientCalls.Add(initialCall);
                State = State.Waiting;
                CancellationTokenSource = new CancellationTokenSource();
            }
        }
    }
}
