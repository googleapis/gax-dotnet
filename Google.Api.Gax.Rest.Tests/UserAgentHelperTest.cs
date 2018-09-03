/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Linq;
using System.Net.Http;
using Xunit;

namespace Google.Api.Gax.Rest.Tests
{
    public class UserAgentHelperTest
    {
        [Fact]
        public void GetDefaultUserAgent()
        {
            Assert.StartsWith("gcloud-dotnet/1.0.0", UserAgentHelper.GetDefaultUserAgent(typeof(UserAgentHelperTest)));
        }

        [Fact]
        public void ModifyHeader_NewHeader()
        {
            var modifier = UserAgentHelper.CreateRequestModifier(typeof(UserAgentHelperTest));

            var request = new HttpRequestMessage();
            modifier(request);
            var values = request.Headers.GetValues(VersionHeaderBuilder.HeaderName).ToList();
            Assert.Equal(1, values.Count);
            Assert.Contains("gccl/", values[0]);
        }

        [Fact]
        public void ModifyHeader_ReplaceHeader()
        {
            var modifier = UserAgentHelper.CreateRequestModifier(typeof(UserAgentHelperTest));

            var request = new HttpRequestMessage
            {
                Headers = { { VersionHeaderBuilder.HeaderName, "replace-me" } }
            };

            modifier(request);
            var values = request.Headers.GetValues(VersionHeaderBuilder.HeaderName).ToList();
            Assert.Equal(1, values.Count);
            Assert.Contains("gccl/", values[0]);
        }
    }
}
