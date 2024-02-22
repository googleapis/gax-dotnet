/*
 * Copyright 2022 Google Inc. All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Threading.Tasks;
using System.Threading;
using System;
using Xunit;

namespace Google.Api.Gax.Rest.Tests;

public partial class ClientBuilderBaseTest
{
    [Fact]
    public void UseSelfSignedJwts_DisabledByDefault()
    {
        var builder = new DefaultsTestBuilder();
        Assert.False(builder.UseJwtAccessWithScopes);
        Assert.Null(builder.UniverseDomain);
    }

    /// <summary>
    /// Builder with no custom behavior, which purely exists to check defaults.
    /// </summary>
    private class DefaultsTestBuilder : ClientBuilderBase<string>
    {
        public override string Build() =>
            throw new NotImplementedException();

        public override Task<string> BuildAsync(CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();

        protected override string GetDefaultApplicationName() =>
            throw new NotImplementedException();

        protected override ScopedCredentialProvider GetScopedCredentialProvider() =>
            throw new NotImplementedException();
    }
}
