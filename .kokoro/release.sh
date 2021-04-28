#!/bin/bash

set -e

SCRIPT=$(readlink -f "$0")
SCRIPT_DIR=$(dirname "$SCRIPT")

cd $SCRIPT_DIR

# Make sure secrets are loaded in a well known location before running releasetool
source ./populatesecrets.sh

# Only populate secrets if we have to.
# Else, we assume secrets have already been populated by the caller.
populatesecrets=true
if [[ "$#" -eq 1 ]] && [[ "$1" == "--skippopulatesecrets" ]]
then
    populatesecrets=false
    echo "Skipping populate secrets."
elif [[ "$#" -gt 0 ]]
then
    echo "Usage: $0 [--skippopulatesecrets]"
    exit 1
fi
if [[ "$populatesecrets" == "true" ]]
then
    populate_all_secrets
fi

cd ..

export NUGET_API_KEY="$(cat "$SECRETS_LOCATION"/google-apis-nuget-api-key)"

# Build the release and run the tests.
./buildrelease.sh $(git rev-parse HEAD)

# Push the changes to nuget.
cd ./releasebuild/nuget
for pkg in *.nupkg; do dotnet nuget push -s https://api.nuget.org/v3/index.json -k $NUGET_API_KEY $pkg; done
