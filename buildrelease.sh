#!/bin/bash

# Script to perform a release build for GAX, based on
# a commit for which tags have been created.
# This builds both GAX and the common protos; but will delete
# all built packages that don't match one of the tags in the commit
# hash. For instance, if there's only one tag in the commit hash 
# that starts with Google.Api.Gax.Grpc then only the following nuget
# packages will remain after the script is done:
# Google.Api.Gax.Grpc.<version>.nupkg
# Google.Api.Gax.Grpc.Gcp.<version>.nupkg
# Google.Api.Gax.Grpc.Testing.<version>.nupkg
# Sample: buildrelease.sh 847118821d8a8b4ac2ea3bbe692acea29c14c4da

set -e

if [[ $# -gt 0 ]];
then
  echo "This script does not take any args"
  exit 1
fi

commit=$(git rev-parse HEAD)

# Do everything from the repository root for sanity.
cd $(dirname $0)

./build.sh

# Turn the multi-line output of git tag --points-at into space-separated list of projects
projects=$(git tag --points-at $commit | sed 's/-.*//g' | awk -vORS=\  '{print $1}' | sed 's/ $//')

if [ -z "$projects" ]
then
  echo "No tags found for commit $commit"
  echo "Deleting all packages generated"
  rm -rf nuget
  exit 1
fi

oldIFS=$IFS
IFS=' '
read -a projectArray <<< "$projects"
IFS=$oldIFS

for package in nuget/*
do
  delete=true
  for projectToKeep in ${projectArray[*]}
  do
    if [[ $package == nuget/$projectToKeep* ]];
    then
      delete=false
	  echo "Keeping package $package"
      break
    fi
  done
  if [ "$delete" = true ];
  then
    echo "Deleting package $package"
    rm -rf $package
  fi
done

echo "Build complete. Push packages from ./nuget."
