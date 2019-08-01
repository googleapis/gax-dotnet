/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.Globalization;
using System.Linq;

namespace Google.Api.Gax.Grpc
{
    /// <summary>
    /// Settings specifying a service endpoint in the form of a host name and port.
    /// This class is immutable and thread-safe.
    /// </summary>
    public sealed class ServiceEndpoint : IEquatable<ServiceEndpoint>
    {
        private const int HttpsPort = 443;
        
        /// <summary>
        /// The host name to connect to. Never null or empty.
        /// </summary>
        public string Host { get; }
        
        /// <summary>
        /// The port to connect to, in the range 1 to 65535 inclusive.
        /// </summary>
        public int Port { get; }

        /// <summary>
        /// Creates a new endpoint with the given host, using a port of 443.
        /// </summary>
        /// <param name="host">The host name to connect to. Must not be null or empty.</param>
        public ServiceEndpoint(string host)
        {
            Host = GaxPreconditions.CheckNotNullOrEmpty(host, nameof(host));
            Port = HttpsPort;
        }

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
        /// Tries to parse the specified value as an endpoint.
        /// </summary>
        /// <remarks>
        /// <para>Valid formats are:</para>
        /// <list type="bullet">
        ///   <item><c>host</c></item>
        ///   <item><c>https://host</c></item>
        ///   <item><c>host:port</c></item>
        ///   <item><c>https://host:port</c></item>
        /// </list>
        /// <para>The port defaults to 443 if it is not otherwise specified. If it is specified, it must be in the range 1-65535 inclusive.</para>
        /// </remarks>
        /// <param name="text">The text to parse.</param>
        /// <param name="endpoint">The resulting endpoint, or <c>null</c> if the value could not be parsed.</param>
        /// <returns><c>true</c> if the value was parsed successfully; <c>false</c> if parsing failed</returns>
        public static bool TryParse(string text, out ServiceEndpoint endpoint) =>
            TryParseInternal(text, out endpoint, out _);

        /// <summary>
        /// Parses the specified value as an endpoint.
        /// </summary>
        /// <remarks>
        /// <para>Valid formats are:</para>
        /// <list type="bullet">
        ///   <item><c>host</c></item>
        ///   <item><c>https://host</c></item>
        ///   <item><c>host:port</c></item>
        ///   <item><c>https://host:port</c></item>
        /// </list>
        /// <para>The port defaults to 443 if it is not otherwise specified. If it is specified, it must be in the range 1-65535 inclusive.</para>
        /// </remarks>
        /// <param name="text">The text to parse.</param>
        /// <returns>The resulting endpoint.</returns>
        /// <exception cref="ArgumentException"><paramref name="text"/> does not represent a valid endpoint.</exception>
        public static ServiceEndpoint Parse(string text) =>
            text is null ? throw new ArgumentNullException(nameof(text)) :
            TryParseInternal(text, out var endpoint, out var errorMessage) ? endpoint
            : throw new ArgumentException(errorMessage, nameof(text));

        private static bool TryParseInternal(string text, out ServiceEndpoint endpoint, out string errorMessage)
        {
            if (text is null)
            {
                errorMessage = "Input cannot be null"; // This will never actually be used.
                endpoint = null;
                return false;
            }
            if (text.StartsWith("https://"))
            {
                text = text.Substring(8);
            }
            int colonIndex = text.IndexOf(':');

            string host;
            int port;
            if (colonIndex == -1)
            {
                host = text;
                port = HttpsPort;
            }
            else
            {
                host = text.Substring(0, colonIndex);
                string portText = text.Substring(colonIndex + 1);
                if (!int.TryParse(portText, NumberStyles.None,  CultureInfo.InvariantCulture, out port))
                {
                    endpoint = null;
                    errorMessage = $"Unable to parse port value: '{portText}'";
                    return false;
                }
                if (port < 1 || port > 65535)
                {
                    endpoint = null;
                    errorMessage = $"Port value {portText} is not in the range 1-65535 inclusive.";
                    return false;
                }
            }
            if (host == "")
            {
                endpoint = null;
                errorMessage = $"Host cannot be empty.";
                return false;
            }

            // While this isn't the only problem we could run into, it's probably the most common one.
            if (host.Any(c => char.IsWhiteSpace(c)))
            {
                endpoint = null;
                errorMessage = "Host values must not contain whitespace";
                return false;
            }
            errorMessage = null;
            endpoint = new ServiceEndpoint(host, port);
            return true;
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

        /// <summary>
        /// Determines equality between this object and <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The object to compare with this one.</param>
        /// <returns><c>true</c> if <paramref name="obj"/> is a <see cref="ServiceEndpoint"/>
        /// with the same host and port; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj) => Equals(obj as ServiceEndpoint);

        /// <summary>
        /// Returns a hash code for this object, consistent with <see cref="Equals(ServiceEndpoint)"/>.
        /// </summary>
        /// <returns>A hash code for this object.</returns>
        public override int GetHashCode() => unchecked(Host.GetHashCode() * 31 + Port);

        /// <summary>
        /// Determines equality between this endpoint and <paramref name="other"/>.
        /// </summary>
        /// <param name="other">The object to compare with this one.</param>
        /// <returns><c>true</c> if <paramref name="other"/> is a <see cref="ServiceEndpoint"/>
        /// with the same host and port; <c>false</c> otherwise.</returns>
        public bool Equals(ServiceEndpoint other) => other != null && other.Host == Host && other.Port == Port;
    }
}
