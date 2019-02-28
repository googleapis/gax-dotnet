#!/bin/bash

set -e

cd $(dirname $0)

# Clean up previous builds
rm -rf {src,test,testing}/*/bin {src,test,testing}/*/obj

CONFIG=Release
# Arguments to use for all build-related commands (build, pack)
DOTNET_BUILD_ARGS="-c $CONFIG"
# Arguments to use for test-related commands (test)
DOTNET_TEST_ARGS="--no-build $DOTNET_BUILD_ARGS"

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
