// Copyright 2018 gRPC authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Grpc.Core;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Grpc.Gcp
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
                bool result = await originalStreamReader.MoveNext(token);
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
