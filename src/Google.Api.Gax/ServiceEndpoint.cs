/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

namespace Google.Api.Gax
{
    /// <summary>
    /// Settings specifying a service endpoint in the form of a host name and port.
    /// This class is immutable and thread-safe.
    /// </summary>
    public sealed class ServiceEndpoint
    {
        /// <summary>
        /// The host name to connect to. Never null or empty.
        /// </summary>
        public string Host { get; }
        
        /// <summary>
        /// The port to connect to, in the range 1 to 65535 inclusive.
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// Creates a new endpoint with the given host and port.
        /// </summary>
        /// <param name="host">The host name to connect to. Must not be null or empty.</param>
        /// <param name="port">The port to connect to, in the range 1 to 65535 inclusive.</param>
        public ServiceEndpoint(string host, int port)
        {
            Host = GaxPreconditions.CheckNotNullOrEmpty(host, nameof(host));
            Port = GaxPreconditions.CheckArgumentRange(port, nameof(port), 1, 65535);
        }

        /// <summary>
        /// Creates a new endpoint with the same port but the given host.
        /// </summary>
        /// <param name="host">The host name to connect to. Must not be null or empty.</param>
        /// <returns>A new endpoint with the current port and the specified host.</returns>
        public ServiceEndpoint WithHost(string host) => new ServiceEndpoint(host, Port);

        /// <summary>
        /// Creates a new endpoint with the same host but the given port.
        /// </summary>
        /// <param name="port">The port to connect to, in the range 1 to 65535 inclusive.</param>
        /// <returns>A new endpoint with the current host and the specified port.</returns>
        public ServiceEndpoint WithPort(int port) => new ServiceEndpoint(Host, port);

        /// <summary>
        /// Returns this endpoint's data in the format "host:port".
        /// </summary>
        /// <returns>This endpoint's data in the format "host:port".</returns>
        public override string ToString() => $"{Host}:{Port}";
    }
}
