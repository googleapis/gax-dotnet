/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;

namespace Google.Api.Gax
{
    /// <summary>
    /// Settings specifying the service API settings; how a client should connect to the service.
    /// </summary>
    public sealed class ServiceEndpointSettings
    {
        private string _host;
        private int? _port;

        /// <summary>
        /// If not null, then the service API host. If null, then the service default host is used.
        /// </summary>
        public string Host
        {
            get { return _host; }
            set
            {
                // Not readily available in GaxPreconditions...
                if (value == "")
                {
                    throw new ArgumentException(nameof(value), "Host must not be empty");
                }
                _host = value;
            }
        }

        /// <summary>
        /// If not null, then the service API port. If null, then the service default port is used.
        /// </summary>
        public int? Port
        {
            get { return _port; }
            set
            {
                // Not readily available in GaxPreconditions...
                if (value != null && (value.Value <= 0 || value.Value >= 65536))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Port must be between 1 and 65535");
                }
                _port = value;
            }
        }

        /// <summary>
        /// Creates a clone of this object, with all the same property values.
        /// </summary>
        /// <returns>A clone of these service API settings.</returns>
        public ServiceEndpointSettings Clone() => new ServiceEndpointSettings
        {
            Host = Host,
            Port = Port,
        };
    }
}
