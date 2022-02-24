/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Grpc.Net.Client;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Interoperability layer for the aspects of gRPC that aren't covered by Grpc.Core.Api.
    /// </summary>
    public abstract class GrpcAdapter
    {
        private static readonly object s_defaultAdapterLock = new object();
        private static GrpcAdapter s_defaultAdapter;

        /// <summary>
        /// Creates a channel for the given endpoint, using the given credentials and options.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Must not be null.</param>
        /// <param name="credentials">The channel credentials to use. Must not be null.</param>
        /// <param name="options">The channel options to use. Must not be null.</param>
        /// <returns>A channel for the specified settings.</returns>
        public ChannelBase CreateChannel(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options)
        {
            GaxPreconditions.CheckNotNull(endpoint, nameof(endpoint));
            GaxPreconditions.CheckNotNull(credentials, nameof(credentials));
            GaxPreconditions.CheckNotNull(options, nameof(options));
            return CreateChannelImpl(endpoint, credentials, options);
        }

        /// <summary>
        /// Creates a channel for the given endpoint, using the given credentials and options. All parameters
        /// are pre-validated to be non-null.
        /// </summary>
        /// <param name="endpoint">The endpoint to connect to. Will not be null.</param>
        /// <param name="credentials">The channel credentials to use. Will not be null.</param>
        /// <param name="options">The channel options to use. Will not be null.</param>
        /// <returns>A channel for the specified settings.</returns>
        protected abstract ChannelBase CreateChannelImpl(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options);

        /// <summary>
        /// Returns the default gRPC adapter based on the available gRPC implementations.
        /// </summary>
        /// <remarks>
        /// FIXME: Add details about the normal detection process here.
        /// </remarks>
        public static GrpcAdapter DefaultAdapter
        {
            get
            {
                lock (s_defaultAdapterLock)
                {
                    return s_defaultAdapter ??= CreateDefaultAdapter();
                }
            }
        }

        // TODO: Is this really what we want? Definitely simple, but not great in other ways...
        // Perhaps have an environment variable that can be used to force one or the other?
        // (In some situations it may be better to see "Grpc.Core fails immediately, but that's the one we want"
        // rather than "Grpc.Net.Client looks like it will work, but then fails".)
        private static GrpcAdapter CreateDefaultAdapter()
        {
            try
            {
                GrpcChannel.ForAddress("https://ignored.com");
                return GrpcNetClientAdapter.Default;
            }
            catch
            {
                return GrpcCoreAdapter.Instance;
            }
        }

        /// <summary>
        /// Clears the default adapter returned by <see cref="DefaultAdapter"/>. The next
        /// time the property is accessed, the default detection process will occur
        /// as documented on the property, unless <see cref="SetDefault(GrpcAdapter)"/> has
        /// been called to set a specific default.
        /// </summary>
        /// <remarks>
        /// This method is primarily present for testing purposes. It is rarely useful within
        /// an application.
        /// </remarks>
        public static void ClearDefault()
        {
            lock (s_defaultAdapter)
            {
                s_defaultAdapter = null;
            }
        }

        /// <summary>
        /// Sets the default adapter returned by <see cref="DefaultAdapter"/> property.
        /// This method must only be called once, before any calls to the property,
        /// unless <see cref="ClearDefault"/>
        /// </summary>
        /// <remarks>
        /// Within applications, this method should generally be called at the very start of the
        /// application. It is rarely appropriate to call this method within a general purpose
        /// library, due to the lack of knowledge of potentially-conflicting application requirements.
        /// </remarks>
        /// <param name="adapter">The gRPC adapter to use by default. Must not be null.</param>
        public static void SetDefault(GrpcAdapter adapter)
        {
            GaxPreconditions.CheckNotNull(adapter, nameof(adapter));
            lock (s_defaultAdapter)
            {
                GaxPreconditions.CheckState(s_defaultAdapter is null, "The default adapter has already been set or accessed.");
                s_defaultAdapter = adapter;
            }
        }
    }
}
