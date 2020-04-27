#!/bin/bash

set -e

cd $(dirname $0)

# Clean up previous builds
rm -rf {src,test,testing}/*/bin {src,test,testing}/*/obj

export Configuration=Release
export ContinuousIntegrationBuild=true

echo CLI args: $DOTNET_BUILD_ARGS

echo Building
dotnet build -nologo -clp:NoSummary -v quiet Gax.sln

echo Testing

for testproject in *.Tests
do
  # This will run the tests on every platform  
  # defined for the project.
  dotnet test -nologo --no-build $testproject
done

# Even though we don't use the generated packages on most
# builds, it's good to make sure we always *can* pack.
echo Packing
dotnet pack Gax.sln --no-build -o $PWD/nuget
