#!/bin/bash

# Script to perform a release build for GAX, based on
# a tag which should already have been created.
# This builds both GAX and the common protos; you should only push
# the nuget packages you actually want to update.
# Sample: buildrelease.sh Google.Api.Gax-2.1.0

# The repo is cloned into a fresh "releasebuild" directory.

set -e

if [ -z "$1" ]
then
  echo Please specify the release tag
  exit 1
fi

tag=$1

# TODO: We don't really want a regex here... just a match.
git fetch -v --dry-run --tags upstream 2>&1 \
  | grep -e $tag > /dev/null \
  || (echo "Tag $tag appears not to exist. Did you create it?"; exit 1)

# Do everything from the repository root for sanity.
cd $(dirname $0)

rm -rf releasebuild
git clone https://github.com/googleapis/gax-dotnet.git releasebuild -c core.autocrlf=input

cd releasebuild
git checkout $tag
export CI=true # Forces SourceLink in the main build.
./build.sh
dotnet pack Gax.sln --no-build -o $PWD/nuget -c Release

echo "Build complete. Push packages from releasebuild/nuget."
