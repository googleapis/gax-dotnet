/*
 * Copyright 2024 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace Google.Api.Gax.Tests;

public class FieldFormatsTest
{
    [Fact]
    public void GenerateUuid4()
    {
        // We generate lots of values to check both uniqueness and formatting.
        int count = 10_000;
        var strings = new HashSet<string>(Enumerable.Range(0, count).Select(_ => FieldFormats.GenerateUuid4()));
        Assert.Equal(count, strings.Count);

        var pattern = new Regex("^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$");
        Assert.All(strings, x => Assert.Matches(pattern, x));
    }
}
