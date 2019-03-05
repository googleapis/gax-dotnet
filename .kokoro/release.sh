#!/bin/bash

set -e

SCRIPT=$(readlink -f "$0")
SCRIPT_DIR=$(dirname "$SCRIPT")

cd $SCRIPT_DIR
cd ..

export NUGET_API_KEY="$(cat "$KOKORO_KEYSTORE_DIR"/73609_google-apis-nuget-api-key)"

# Build the release and run the tests.
./buildrelease.sh $(git rev-parse HEAD)

# Push the changes to nuget.
cd ./releasebuild/nuget
for pkg in *.nupkg; do dotnet nuget push -s https://api.nuget.org/v3/index.json -k $NUGET_API_KEY $pkg; done
