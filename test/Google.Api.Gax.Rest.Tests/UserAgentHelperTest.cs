/*
 * Copyright 2016 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Xunit;

namespace Google.Api.Gax.Rest.Tests
{
    public class UserAgentHelperTest
    {
        [Fact]
        public void GetDefaultUserAgent()
        {
            // Always 1.0.0, because we don't declare a version nubmer in project.json for tests.
            Assert.Equal("gcloud-dotnet/1.0.0", UserAgentHelper.GetDefaultUserAgent(typeof(UserAgentHelperTest)));
        }
    }
}
