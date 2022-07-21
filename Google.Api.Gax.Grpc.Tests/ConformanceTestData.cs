/*
 * Copyright 2022 Google LLC
 * Use of this source code is governed by a BSD-style
 * license that can be found in the LICENSE file or at
 * https://developers.google.com/open-source/licenses/bsd
 */

using System;
using System.IO;

namespace Google.Api.Gax.Grpc.Tests;

/// <summary>
/// Utility code for locating and loading test data.
/// </summary>
public static class ConformanceTestData
{
    /// <summary>
    /// Finds the root directory of the repository by looking for common files.
    /// </summary>
    public static string FindRepositoryRootDirectory()
    {
        var currentDirectory = Path.GetFullPath(".");
        var directory = new DirectoryInfo(currentDirectory);
        while (directory != null &&
            (!File.Exists(Path.Combine(directory.FullName, "LICENSE"))
            || !Directory.Exists(Path.Combine(directory.FullName, "Google.Api.CommonProtos"))))
        {
            directory = directory.Parent;
        }
        if (directory == null)
        {
            throw new InvalidOperationException("Unable to determine root directory. Please run within gax-dotnet repository.");
        }
        return directory.FullName;
    }
}
