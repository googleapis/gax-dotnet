#!/bin/bash

set -e

cd $(dirname $0)

# Clean up previous builds
rm -rf {src,test,testing}/*/bin {src,test,testing}/*/obj

# Make sure that SourceLink uses the GitHub repo, even if that's not where
# our origin remote points at.
git remote add github https://github.com/GoogleCloudPlatform/functions-framework-dotnet.git
export GitRepositoryRemoteName=github

export Configuration=Release
export ContinuousIntegrationBuild=true

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

# Remove the github remote so that if there are multiple iterations
# against the same clone, the "git remote add" earlier will work.
git remote remove github
