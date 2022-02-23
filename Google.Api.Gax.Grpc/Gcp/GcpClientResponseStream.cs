/*
 * Copyright 2018 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Api.Gax.Grpc.Gcp
{
    /// <summary>
    ///  A wrapper class for handling post process for server streaming responses.
    /// </summary>
    /// <typeparam name="TRequest">The type representing the request.</typeparam>
    /// <typeparam name="TResponse">The type representing the response.</typeparam>
    internal class GcpClientResponseStream<TRequest, TResponse> : IAsyncStreamReader<TResponse>
        where TRequest : class
        where TResponse : class
    {
        bool callbackDone = false;
        readonly IAsyncStreamReader<TResponse> originalStreamReader;
        TResponse lastResponse;
        Action<TResponse> postProcess;

        public GcpClientResponseStream(IAsyncStreamReader<TResponse> originalStreamReader, Action<TResponse> postProcess)
        {
            this.originalStreamReader = originalStreamReader;
            this.postProcess = postProcess;
        }

        public TResponse Current
        {
            get
            {
                TResponse current = originalStreamReader.Current;
                // Record the last response.
                lastResponse = current;
                return current;
            }
        }

        public async Task<bool> MoveNext(CancellationToken token)
        {
            bool executeCallback = false;
            try
            {
                bool result = await originalStreamReader.MoveNext(token).ConfigureAwait(false);
                // The last invocation of originalStreamReader.MoveNext returns false if it finishes successfully.
                if (!result)
                {
                    executeCallback = true;
                }
                return result;
            }
            finally
            {
                // If stream is successfully processed or failed, execute the callback.
                // We ensure the callback is called only once.
                if (executeCallback && !callbackDone)
                {
                    postProcess(lastResponse);
                    callbackDone = true;
                }
            }
        }
    }
}
