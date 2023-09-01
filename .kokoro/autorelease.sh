#!/bin/bash

set -e

SCRIPT=$(readlink -f "$0")
SCRIPT_DIR=$(dirname "$SCRIPT")

cd $SCRIPT_DIR

# Make sure secrets are loaded in a well known location before running
# the release reporter script.
source ./populatesecrets.sh
populate_all_secrets

dotnet tool restore
source <(dotnet release-progress-reporter publish-reporter-script)

# Secrets are already populated, let's not do that again
./release.sh --skippopulatesecrets
