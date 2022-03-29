/*
 * Copyright 2018 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Google.Protobuf;
using Google.Protobuf.Collections;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Gcp
{
    /// <summary>
    /// Call invoker which can fan calls out to multiple underlying channels
    /// based on request properties.
    /// </summary>
    internal sealed class GcpCallInvoker : CallInvoker
    {
        private static int s_clientChannelIdCounter;

        private const string ClientChannelId = "grpc_gcp.client_channel.id";

        // Lock to protect the channel reference collections, as they're not thread-safe.
        private readonly object _thisLock = new object();
        private readonly IDictionary<string, ChannelRef> _channelRefByAffinityKey = new Dictionary<string, ChannelRef>();
        private readonly IList<ChannelRef> _channelRefs = new List<ChannelRef>();

        // Access to these fields does not need to be protected by the lock: the objects are never modified.
        private readonly string _target;
        private readonly ApiConfig _apiConfig;
        private readonly IDictionary<string, AffinityConfig> _affinityByMethod;
        private readonly ChannelCredentials _credentials;
        private readonly GrpcChannelOptions _channelOptions;
        private readonly GrpcAdapter _adapter;
        private readonly ApiMetadata _apiMetadata;

        /// <summary>
        /// Initializes a new instance of the <see cref="Grpc.Gcp.GcpCallInvoker"/> class.
        /// </summary>
        /// <param name="apiMetadata"></param>
        /// <param name="target">Target of the underlying grpc channels. Must not be null.</param>
        /// <param name="credentials">Credentials to secure the underlying grpc channels. Must not be null.</param>
        /// <param name="options">Channel options to be used by the underlying grpc channels. Must not be null.</param>
        /// <param name="apiConfig">The API config to apply. Must not be null.</param>
        /// <param name="adapter">The adapter to use to create channels. Must not be null.</param>
        internal GcpCallInvoker(ApiMetadata apiMetadata, string target, ChannelCredentials credentials, GrpcChannelOptions options, ApiConfig apiConfig, GrpcAdapter adapter)
        {
            _apiMetadata = GaxPreconditions.CheckNotNull(apiMetadata, nameof(apiMetadata));
            _target = GaxPreconditions.CheckNotNull(target, nameof(target));
            _credentials = GaxPreconditions.CheckNotNull(credentials, nameof(credentials));
            _channelOptions = GaxPreconditions.CheckNotNull(options, nameof(options));
            _apiConfig = GaxPreconditions.CheckNotNull(apiConfig, nameof(apiConfig)).Clone();
            _adapter = GaxPreconditions.CheckNotNull(adapter, nameof(adapter));

            GaxPreconditions.CheckArgument(this._apiConfig.ChannelPool is object, nameof(apiConfig), "Invalid API config: no channel pool settings");
            _affinityByMethod = InitAffinityByMethodIndex(this._apiConfig);
        }

        private static IDictionary<string, AffinityConfig> InitAffinityByMethodIndex(ApiConfig config)
        {
            IDictionary<string, AffinityConfig> index = new Dictionary<string, AffinityConfig>();
            foreach (MethodConfig method in config.Method)
            {
                // TODO(fengli): supports wildcard in method selector.
                foreach (string name in method.Name)
                {
                    index.Add(name, method.Affinity);
                }
            }
            return index;
        }

        private ChannelRef GetChannelRef(string affinityKey = null)
        {
            // TODO(fengli): Supports load reporting.
            lock (_thisLock)
            {
                if (!string.IsNullOrEmpty(affinityKey))
                {
                    // Finds the gRPC channel according to the affinity key.
                    if (_channelRefByAffinityKey.TryGetValue(affinityKey, out ChannelRef channelRef))
                    {
                        return channelRef;
                    }
                    // TODO(fengli): Affinity key not found, log an error.
                }

                // TODO(fengli): Creates new gRPC channels on demand, depends on the load reporting.
                IOrderedEnumerable<ChannelRef> orderedChannelRefs =
                    _channelRefs.OrderBy(channelRef => channelRef.ActiveStreamCount);
                foreach (ChannelRef channelRef in orderedChannelRefs)
                {
                    if (channelRef.ActiveStreamCount < _apiConfig.ChannelPool.MaxConcurrentStreamsLowWatermark)
                    {
                        // If there's a free channel, use it.
                        return channelRef;
                    }
                    else
                    {
                        //  If all channels are busy, break.
                        break;
                    }
                }
                int count = _channelRefs.Count;
                if (count < _apiConfig.ChannelPool.MaxSize)
                {
                    // Creates a new gRPC channel.
                    // TODO: Logging?
                    // GrpcEnvironment.Logger.Info("Grpc.Gcp creating new channel");
                    ChannelBase channel = _adapter.CreateChannel(_apiMetadata, _target, _credentials, _channelOptions.WithCustomOption(ClientChannelId, Interlocked.Increment(ref s_clientChannelIdCounter)));
                    ChannelRef channelRef = new ChannelRef(channel, count);
                    _channelRefs.Add(channelRef);
                    return channelRef;
                }
                // If all channels are overloaded and the channel pool is full already,
                // return the channel with least active streams.
                return orderedChannelRefs.First();
            }
        }

        private List<string> GetAffinityKeysFromProto(string affinityKey, IMessage message)
        {
            List<string> affinityKeyValues = new List<string>();
            if (!string.IsNullOrEmpty(affinityKey))
            {
                string[] names = affinityKey.Split('.');
                GetAffinityKeysFromProto(names, 0, message, affinityKeyValues);
            }
            return affinityKeyValues;
        }

        private void GetAffinityKeysFromProto(string[] names, int namesIndex, IMessage message, List<string> affinityKeyValues)
        {
            if (namesIndex >= names.Length)
            {
                throw new InvalidOperationException($"Affinity key {string.Join(".", names)} missing field name for message {message.Descriptor.Name}.");
            }

            string name = names[namesIndex];
            var field = message.Descriptor.FindFieldByName(name);
            if (field == null)
            {
                throw new InvalidOperationException($"Field {name} not present in message {message.Descriptor.Name}");
            }
            var accessor = field.Accessor;
            if (accessor == null)
            {
                throw new InvalidOperationException($"Field {name} in message {message.Descriptor.Name} has no accessor");
            }
            int lastIndex = names.Length - 1;
            switch (accessor.GetValue(message))
            {
                case string text when namesIndex < lastIndex:
                case RepeatedField<string> texts when namesIndex < lastIndex:
                    throw new InvalidOperationException($"Field {name} in message {message.Descriptor.Name} is neither a message or repeated message field.");
                case string text:
                    affinityKeyValues.Add(text);
                    break;
                case RepeatedField<string> texts:
                    affinityKeyValues.AddRange(texts);
                    break;
                case IMessage nestedMessage:
                    GetAffinityKeysFromProto(names, namesIndex + 1, nestedMessage, affinityKeyValues);
                    break;
                // We can't use RepeatedField<IMessage> because RepeatedField<T> is not
                // covariant on T. But IEnumerable<T> is covariant on T.
                // We can safely assume that any IEnumerable<IMessage> is really
                // a RepeatedField<T> where T is IMessage.
                case IEnumerable<IMessage> nestedMessages:
                    foreach (IMessage nestedMessage in nestedMessages)
                    {
                        GetAffinityKeysFromProto(names, namesIndex + 1, nestedMessage, affinityKeyValues);
                    }
                    break;
                case null:
                    // Probably a nested message, but with no value. Just don't use an affinity key.
                    break;
                default:
                    throw new InvalidOperationException($"Field {name} in message {message.Descriptor.Name} is neither a string or repeated string field nor another message or repeated message field.");
            }
        }

        private void Bind(ChannelRef channelRef, string affinityKey)
        {
            if (!string.IsNullOrEmpty(affinityKey))
            {
                lock (_thisLock)
                {
                    // TODO: What should we do if the dictionary already contains this key, but for a different channel ref?
                    if (!_channelRefByAffinityKey.Keys.Contains(affinityKey))
                    {
                        _channelRefByAffinityKey.Add(affinityKey, channelRef);
                    }
                    _channelRefByAffinityKey[affinityKey].AffinityCountIncr();
                }
            }
        }

        private void Unbind(string affinityKey)
        {
            if (!string.IsNullOrEmpty(affinityKey))
            {
                lock (_thisLock)
                {
                    if (_channelRefByAffinityKey.TryGetValue(affinityKey, out ChannelRef channelRef))
                    {
                        int newCount = channelRef.AffinityCountDecr();

                        // We would expect it to be exactly 0, but it doesn't hurt to be cautious.
                        if (newCount <= 0)
                        {
                            _channelRefByAffinityKey.Remove(affinityKey);
                        }
                    }
                }
            }
        }

        private ChannelRef PreProcess<TRequest>(AffinityConfig affinityConfig, TRequest request)
        {
            // Gets the affinity bound key if required in the request method.
            string boundKey = null;
            if (affinityConfig != null && affinityConfig.Command == AffinityConfig.Types.Command.Bound)
            {
                boundKey = GetAffinityKeysFromProto(affinityConfig.AffinityKey, (IMessage)request).SingleOrDefault();
            }

            ChannelRef channelRef = GetChannelRef(boundKey);
            channelRef.ActiveStreamCountIncr();
            return channelRef;
        }

        // Note: response may be default(TResponse) in the case of a failure. We only expect to be called from
        // protobuf-based calls anyway, so it will always be a class type, and will never be null for success cases.
        // We can therefore check for nullity rather than having a separate "success" parameter.
        private void PostProcess<TRequest, TResponse>(AffinityConfig affinityConfig, ChannelRef channelRef, TRequest request, TResponse response)
        {
            channelRef.ActiveStreamCountDecr();
            // Process BIND or UNBIND if the method has affinity feature enabled, but only for successful calls.
            if (affinityConfig != null && response != null)
            {
                if (affinityConfig.Command == AffinityConfig.Types.Command.Bind)
                {
                    foreach (string bindingKey in GetAffinityKeysFromProto(affinityConfig.AffinityKey, (IMessage)response))
                    {
                        Bind(channelRef, bindingKey);
                    }
                }
                else if (affinityConfig.Command == AffinityConfig.Types.Command.Unbind)
                {
                    foreach (string unbindingKey in GetAffinityKeysFromProto(affinityConfig.AffinityKey, (IMessage)request))
                    {
                        Unbind(unbindingKey);
                    }
                }
            }
        }

        /// <summary>
        /// Invokes a client streaming call asynchronously.
        /// In client streaming scenario, client sends a stream of requests and server responds with a single response.
        /// </summary>
        public override AsyncClientStreamingCall<TRequest, TResponse>
            AsyncClientStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options)
        {
            // No channel affinity feature for client streaming call.
            ChannelRef channelRef = GetChannelRef();

            var originalCall = channelRef.CallInvoker.AsyncClientStreamingCall(method, host, options);

            // Decrease the active streams count once async response finishes.
            var gcpResponseAsync = DecrementCountAndPropagateResult(originalCall.ResponseAsync);

            // Create a wrapper of the original AsyncClientStreamingCall.
            return new AsyncClientStreamingCall<TRequest, TResponse>(
                originalCall.RequestStream,
                gcpResponseAsync,
                originalCall.ResponseHeadersAsync,
                () => originalCall.GetStatus(),
                () => originalCall.GetTrailers(),
                () => originalCall.Dispose());

            async Task<TResponse> DecrementCountAndPropagateResult(Task<TResponse> task)
            {
                try
                {
                    return await task.ConfigureAwait(false);
                }
                finally
                {
                    channelRef.ActiveStreamCountDecr();
                }
            }
        }

        /// <summary>
        /// Invokes a duplex streaming call asynchronously.
        /// In duplex streaming scenario, client sends a stream of requests and server responds with a stream of responses.
        /// The response stream is completely independent and both side can be sending messages at the same time.
        /// </summary>
        public override AsyncDuplexStreamingCall<TRequest, TResponse>
            AsyncDuplexStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options)
        {
            // No channel affinity feature for duplex streaming call.
            ChannelRef channelRef = GetChannelRef();
            var originalCall = channelRef.CallInvoker.AsyncDuplexStreamingCall(method, host, options);

            // Decrease the active streams count once the streaming response finishes its final batch.
            var gcpResponseStream = new GcpClientResponseStream<TRequest, TResponse>(
                originalCall.ResponseStream,
                (resp) => channelRef.ActiveStreamCountDecr());

            // Create a wrapper of the original AsyncDuplexStreamingCall.
            return new AsyncDuplexStreamingCall<TRequest, TResponse>(
                originalCall.RequestStream,
                gcpResponseStream,
                originalCall.ResponseHeadersAsync,
                () => originalCall.GetStatus(),
                () => originalCall.GetTrailers(),
                () => originalCall.Dispose());
        }

        /// <summary>
        /// Invokes a server streaming call asynchronously.
        /// In server streaming scenario, client sends on request and server responds with a stream of responses.
        /// </summary>
        public override AsyncServerStreamingCall<TResponse>
            AsyncServerStreamingCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            _affinityByMethod.TryGetValue(method.FullName, out AffinityConfig affinityConfig);

            ChannelRef channelRef = PreProcess(affinityConfig, request);

            var originalCall = channelRef.CallInvoker.AsyncServerStreamingCall(method, host, options, request);

            // Executes affinity postprocess once the streaming response finishes its final batch.
            var gcpResponseStream = new GcpClientResponseStream<TRequest, TResponse>(
                originalCall.ResponseStream,
                (resp) => PostProcess(affinityConfig, channelRef, request, resp));

            // Create a wrapper of the original AsyncServerStreamingCall.
            return new AsyncServerStreamingCall<TResponse>(
                gcpResponseStream,
                originalCall.ResponseHeadersAsync,
                () => originalCall.GetStatus(),
                () => originalCall.GetTrailers(),
                () => originalCall.Dispose());
        }

        /// <summary>
        /// Invokes a simple remote call asynchronously.
        /// </summary>
        public override AsyncUnaryCall<TResponse>
            AsyncUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            _affinityByMethod.TryGetValue(method.FullName, out AffinityConfig affinityConfig);

            ChannelRef channelRef = PreProcess(affinityConfig, request);

            var originalCall = channelRef.CallInvoker.AsyncUnaryCall<TRequest, TResponse>(method, host, options, request);

            // Executes affinity postprocess once the async response finishes.
            var gcpResponseAsync = PostProcessPropagateResult(originalCall.ResponseAsync);

            // Create a wrapper of the original AsyncUnaryCall.
            return new AsyncUnaryCall<TResponse>(
                gcpResponseAsync,
                originalCall.ResponseHeadersAsync,
                () => originalCall.GetStatus(),
                () => originalCall.GetTrailers(),
                () => originalCall.Dispose());

            async Task<TResponse> PostProcessPropagateResult(Task<TResponse> task)
            {
                TResponse response = default(TResponse);
                try
                {
                    response = await task.ConfigureAwait(false);
                    return response;
                }
                finally
                {
                    PostProcess(affinityConfig, channelRef, request, response);
                }
            }
        }

        /// <summary>
        /// Invokes a simple remote call in a blocking fashion.
        /// </summary>
        public override TResponse
            BlockingUnaryCall<TRequest, TResponse>(Method<TRequest, TResponse> method, string host, CallOptions options, TRequest request)
        {
            _affinityByMethod.TryGetValue(method.FullName, out AffinityConfig affinityConfig);

            ChannelRef channelRef = PreProcess(affinityConfig, request);

            TResponse response = default(TResponse);
            try
            {
                response = channelRef.CallInvoker.BlockingUnaryCall(method, host, options, request);
                return response;
            }
            finally
            {
                PostProcess(affinityConfig, channelRef, request, response);
            }
        }

        /// <summary>
        /// Shuts down the all channels in the underlying channel pool cleanly. It is strongly
        /// recommended to shutdown all previously created channels before exiting from the process.
        /// </summary>
        public async Task ShutdownAsync()
        {
            for (int i = 0; i < _channelRefs.Count; i++)
            {
                await _channelRefs[i].Channel.ShutdownAsync().ConfigureAwait(false);
            }
        }

        // Test helper methods

        /// <summary>
        /// Returns a deep clone of the internal list of channel references.
        /// This method should only be used in tests.
        /// </summary>
        internal IList<ChannelRef> GetChannelRefsForTest()
        {
            lock (_thisLock)
            {
                // Create an independent copy
                return _channelRefs.Select(cr => cr.Clone()).ToList();
            }
        }

        /// <summary>
        /// Returns a deep clone of the internal dictionary of channel references by affinity key.
        /// This method should only be used in tests.
        /// </summary>
        internal IDictionary<string, ChannelRef> GetChannelRefsByAffinityKeyForTest()
        {
            lock (_thisLock)
            {
                // Create an independent copy
                return _channelRefByAffinityKey.ToDictionary(pair => pair.Key, pair => pair.Value.Clone());
            }
        }
    }
}
