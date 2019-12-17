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

echo Building with CORE_API_ONLY
# Check that Google.Api.Gax.Grpc doesn't expose any non-Grpc.Core.Api in the public surface
# (This relies on being careful where we use CORE_API_ONLY; an alternative would
# be to check the actual public API surface with a separate tool.)
dotnet build -nologo -clp:NoSummary -p:CORE_API_ONLY=True Google.Api.Gax.Grpc
# Make sure we don't end up using that build elsewhere.
dotnet clean -nologo -clp:NoSummary -v quiet Google.Api.Gax.Grpc

echo Building
dotnet build -nologo -clp:NoSummary -v quiet $DOTNET_BUILD_ARGS Gax.sln

echo Testing

for testproject in *.Tests
do
  # This will run the tests on every platform  
  # defined for the project.
  dotnet test -nologo --no-build $DOTNET_TEST_ARGS $testproject
done
