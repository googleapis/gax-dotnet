/*
 * Copyright 2024 Google LLC All Rights Reserved.
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using Xunit;

namespace Google.Api.Gax.Tests;

public class ActivitySourcesTest
{
    [Fact]
    public void NameIsType()
    {
        var source = ActivitySources.FromClientType<ActivitySourcesTest>();
        // Hard-coded to makeit obvious in the test what the value will actually look like.
        Assert.Equal("Google.Api.Gax.Tests.ActivitySourcesTest", source.Name);
    }

    [Fact]
    public void Caching()
    {
        var source1 = ActivitySources.FromClientType<ActivitySourcesTest>();
        var source2 = ActivitySources.FromClientType<ActivitySourcesTest>();
        var source3 = ActivitySources.FromClientType(typeof(ActivitySourcesTest));
        var source4 = ActivitySources.FromClientType<PollingTest>();

        Assert.Same(source1, source2);
        Assert.Same(source1, source3);
        Assert.NotSame(source1, source4);
    }

    [Fact]
    public void Version_VersionedAssembly()
    {
        // Deliberately use a type in the main assembly, so that it's got a real version.
        var source = ActivitySources.FromClientType<Expiration>();
        Assert.NotEmpty(source.Version);
        // We don't try to parse this as a System.Version, as that would fail for betas etc.
        var majorVersion = int.Parse(source.Version.Split('.')[0]);
        // This doesn't need to be changed when we bump the version of GAX - it's just checking
        // that we've got a real version rather than a default of 1.0.
        Assert.True(majorVersion >= 4);
    }
}
