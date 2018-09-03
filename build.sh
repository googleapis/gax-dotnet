#!/bin/bash

set -e

# Myget has sometimes used caps and sometimes not for
# its environment variables...
if [ -n "$PrereleaseTag" -a -z "$PRERELEASETAG" ]
then
  PRERELEASETAG="$PrereleaseTag"
fi

# Clean up previous builds
rm -rf {src,test,testing}/*/bin {src,test,testing}/*/obj

CONFIG=Release
# Arguments to use for all build-related commands (build, pack)
DOTNET_BUILD_ARGS="-c $CONFIG"
# Arguments to use for test-related commands (test)
DOTNET_TEST_ARGS="--no-build $DOTNET_BUILD_ARGS"

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
dotnet restore -v minimal Gax.sln

echo Building
dotnet build $DOTNET_BUILD_ARGS Gax.sln

echo Testing

for testproject in *.Tests
do
  # This will run the tests on every platform  
  # defined for the project.
  dotnet test $DOTNET_TEST_ARGS $testproject
done
