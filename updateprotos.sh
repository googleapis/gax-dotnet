#!/bin/bash

set -e

# Updates the protos in Google.Api.CommonProtos/protos, but
# does not generate code from them.

rm -rf tmp
git clone --recursive https://github.com/googleapis/googleapis tmp --depth=1

rm -rf Google.Api.CommonProtos/protos
mkdir -p Google.Api.CommonProtos/protos/google/api
mkdir -p Google.Api.CommonProtos/protos/google/rpc/context
mkdir -p Google.Api.CommonProtos/protos/google/type
cp tmp/google/api/*.proto Google.Api.CommonProtos/protos/google/api
cp tmp/google/rpc/*.proto Google.Api.CommonProtos/protos/google/rpc
cp tmp/google/rpc/context/*.proto Google.Api.CommonProtos/protos/google/rpc/context
cp tmp/google/type/*.proto Google.Api.CommonProtos/protos/google/type

rm -rf tmp
