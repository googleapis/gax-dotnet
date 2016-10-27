#!/bin/bash

set -e

# Myget has sometimes used caps and sometimes not for
# its environment variables...
if [ -n "$PrereleaseTag" -a -z "$PRERELEASETAG" ]
then
  PRERELEASETAG="$PrereleaseTag"
fi

if [ $(dotnet --info | grep "OS Platform" | grep -c Windows) -ne 0 ]
then
  OS=Windows
else
  OS=Linux
fi

FIND=/usr/bin/find

CONFIG=Release
# Arguments to use for all build-related commands (build, pack)
DOTNET_BUILD_ARGS="-c $CONFIG"
# Arguments to use for test-related commands (test)
DOTNET_TEST_ARGS="$DOTNET_BUILD_ARGS"

# Three options:
# - No environment variables: make sure it's not for release
# - PRERELEASETAG set: use that
# - NOVERSIONSUFFIX set: use no suffix; build as per project.json
if [ -n "$PRERELEASETAG" ]
then
  DOTNET_BUILD_ARGS="$DOTNET_BUILD_ARGS --version-suffix $PRERELEASETAG"
elif [ -z "$NOVERSIONSUFFIX" ]
then
  DOTNET_BUILD_ARGS="$DOTNET_BUILD_ARGS --version-suffix dont-release"  
fi

echo CLI args: $DOTNET_BUILD_ARGS

echo Restoring
dotnet restore -v Warning

echo Building
dotnet build $DOTNET_BUILD_ARGS `$FIND src -mindepth 1 -maxdepth 1 -name 'Google*' -type d`
dotnet build $DOTNET_BUILD_ARGS `$FIND test -mindepth 1 -maxdepth 1 -name 'Google*' -type d`
dotnet build $DOTNET_BUILD_ARGS `$FIND testing -mindepth 1 -maxdepth 1 -name 'Google*' -type d`

# TODO: Tests. We need to:
# - Run Mono for all tests
# - Run dotnet test for all netcore-supporting tests.

echo Testing

for testdir in test/*.Tests
do
  if [ $OS == "Windows" ]
  then
    dotnet test --no-build -f net451 $DOTNET_TEST_ARGS $testdir 
  else
    project=`echo $testdir | cut -d/ -f2`
    bin=$testdir/bin/$CONFIG/net451/ubuntu.14.04-x64
    mono $bin/dotnet-test-xunit.exe $bin/$project.dll
  fi
done

# TODO: Work out all projects we can test with dotnet test
# automatically

dotnet test -f netcoreapp1.0 $DOTNET_TEST_ARGS test/Google.Api.Gax.Rest.Tests

echo Packing

# Assume each packagable project contains something like "version": "1.0.0-*"
# and no other projects do.
for package in `$FIND . -name project.json | xargs grep -le 'version.*-\*' | sed 's/\/project.json//g'`
do
  dotnet pack --no-build $DOTNET_BUILD_ARGS $package
done
