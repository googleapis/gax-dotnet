#!/bin/bash

set -e

SCRIPT=$(readlink -f "$0")
SCRIPT_DIR=$(dirname "$SCRIPT")

cd $SCRIPT_DIR
cd ..

# Make sure secrets are loaded in a well known localtion before running releasetool
source ./populatesecrets.sh
populate_all_secrets

export NUGET_API_KEY="$(cat "$SECRETS_LOCATION"/google-apis-nuget-api-key)"

# Build the release and run the tests.
./buildrelease.sh $(git rev-parse HEAD)

# Push the changes to nuget.
cd ./releasebuild/nuget
for pkg in *.nupkg; do dotnet nuget push -s https://api.nuget.org/v3/index.json -k $NUGET_API_KEY $pkg; done
