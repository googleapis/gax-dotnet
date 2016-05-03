/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Grpc.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xunit;

namespace Google.Api.Gax.Tests
{
    /*public class ClientHelperTest
    {
        private string RemoveUserAgent(Metadata metadata)
        {
            var userAgentEntries = metadata
                .Where(entry => entry.Key.Equals(UserAgentBuilder.HeaderName, StringComparison.InvariantCultureIgnoreCase))
                .ToList();           
            foreach (var entry in userAgentEntries)
            {
                metadata.Remove(entry);
            }
            return string.Join(" ", userAgentEntries.Select(entry => entry.Value));
        }

        private class DummySettings : ServiceSettingsBase
        {
            public DummySettings() { }

            private DummySettings(DummySettings existing) : base(existing) { }

            public DummySettings Clone() => new DummySettings(this);
        }
    }*/
}
