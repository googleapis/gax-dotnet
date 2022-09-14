#!/bin/bash

set -e

SCRIPT=$(readlink -f "$0")
SCRIPT_DIR=$(dirname "$SCRIPT")

cd $SCRIPT_DIR

# Make sure secrets are loaded in a well known localtion before running releasetool
source ./populatesecrets.sh
populate_all_secrets

# Make sure we have the most recent version of pip, then install other packages.
python -m pip install --require-hashes -r pip-requirements.txt
python -m pip install --require-hashes -r requirements.txt
python -m releasetool publish-reporter-script > /tmp/publisher-script

# The publish reporter script uses "python3" which doesn't exist on Windows.
# Work out what we should use instead.
# Try to detect Python 3. It's quite different between Windows and Linux.
if which python > /dev/null && python --version 2>&1 | grep -q "Python 3"; then declare -r PYTHON3=python
elif which py > /dev/null && py -3 --version 2>&1 | grep -q "Python 3"; then declare -r PYTHON3="py -3"
elif which python3 > /dev/null && python3 --version 2>&1 | grep -q "Python 3"; then declare -r PYTHON3=python3
else
  echo "Unable to detect Python 3 installation."
  exit 1
fi

# Fix up the publish reporter script using $PYTHON3. We assume this won't
# be harmful within sed - at the moment it's always "python", "py -3" or "python3".
sed -i "s/python3/$PYTHON3/g" /tmp/publisher-script

source /tmp/publisher-script

# Secrets are already populated, let's not do that again
./release.sh --skippopulatesecrets
