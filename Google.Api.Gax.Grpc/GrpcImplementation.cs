/*
 * Copyright 2020 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using System;
using System.Threading;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Interoperability layer for the aspects of gRPC that aren't covered by Grpc.Core.Api.
    /// Currently internal, and only a Grpc.Core implementation exists - but it should be possible to 
    /// create an implementation for Grpc.Net.Client too.
    /// Unclear as yet whether this should be:
    /// - A sealed class constructed from delegates
    /// - An abstract class
    /// - An interface
    /// - Just a delegate
    /// </summary>
    internal sealed class GrpcImplementation
    {
        /// <summary>
        /// Returns the default implementation, based on which assemblies are available at execution time.
        /// Grpc.Core is preferred over Grpc.Net.Client.
        /// </summary>
        /// <remarks>
        /// Unlike <see cref="GrpcCore"/> and <see cref="GrpcNetClient"/>, this property never returns null.
        /// </remarks>
        public static GrpcImplementation Default => GrpcCore ?? GrpcNetClient ??
            throw new InvalidOperationException("No gRPC implementation could be detected.");

        /// <summary>
        /// Returns a Grpc.Core-based implementation if the assembly is available, or null otherwise.
        /// (Currently always returns a non-null value.)
        /// </summary>
        public static GrpcImplementation GrpcCore => s_grpcCore.Value;

        /// <summary>
        /// Returns a Grpc.Net.Client-based implementation if the assembly is available, or null otherwise.
        /// (Currently always returns null.)
        /// </summary>
        public static GrpcImplementation GrpcNetClient => s_grpcNetClient.Value;

        private static readonly Lazy<GrpcImplementation> s_grpcCore =
            new Lazy<GrpcImplementation>(CreateGrpcCoreImplementation, LazyThreadSafetyMode.ExecutionAndPublication);
        private static readonly Lazy<GrpcImplementation> s_grpcNetClient =
            new Lazy<GrpcImplementation>(CreateGrpcNetClientImplementation, LazyThreadSafetyMode.ExecutionAndPublication);

        private readonly Func<string, ChannelCredentials, GrpcChannelOptions, ChannelBase> _channelCreator;

        private GrpcImplementation(Func<string, ChannelCredentials, GrpcChannelOptions, ChannelBase> channelCreator) =>
            _channelCreator = channelCreator;

        internal ChannelBase CreateChannel(string endpoint, ChannelCredentials credentials, GrpcChannelOptions options) =>
            _channelCreator(endpoint, credentials, options);

        private static GrpcImplementation CreateGrpcCoreImplementation() => new GrpcImplementation(new GrpcCoreChannelFactory().CreateChannel);

        private static GrpcImplementation CreateGrpcNetClientImplementation() => null;
    }
}
