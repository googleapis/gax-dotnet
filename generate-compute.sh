#!/bin/bash

set -e

declare -r REPO_ROOT=$(readlink -f $(dirname ${BASH_SOURCE}))
declare -r PROTOC_VERSION=3.13.0
declare -r GRPC_VERSION=2.31.0
declare -r TOOL_PACKAGES=$REPO_ROOT/tmp/packages
declare -r PROTOBUF_TOOLS_ROOT=$TOOL_PACKAGES/Google.Protobuf.Tools.$PROTOC_VERSION

# Cross-platform tools
case "$OSTYPE" in
  linux*)
    declare -r PROTOC=$PROTOBUF_TOOLS_ROOT/tools/linux_x64/protoc
    declare -r GRPC_PLUGIN=packages/Grpc.Tools.$GRPC_VERSION/tools/linux_x64/grpc_csharp_plugin
    ;;
  darwin*)
    declare -r PROTOC=$PROTOBUF_TOOLS_ROOT/tools/macosx_x64/protoc
    declare -r GRPC_PLUGIN=packages/Grpc.Tools.$GRPC_VERSION/tools/macosx_x64/grpc_csharp_plugin
    ;;
  win* | msys* | cygwin*)
    declare -r PROTOC=$PROTOBUF_TOOLS_ROOT/tools/windows_x64/protoc.exe
    declare -r GRPC_PLUGIN=packages/Grpc.Tools.$GRPC_VERSION/tools/windows_x64/grpc_csharp_plugin.exe
    ;;
  *)
    echo "Unknown OSTYPE: $OSTYPE"
    exit 1
esac

# Copies of code from google-cloud-dotnet/toolversions.sh
install_nuget_package() {
  local output=$TOOL_PACKAGES/$1.$2
  # Assume that if the directory exists, it's already installed correctly.  
  if [[ -d $output ]]; then return 0; fi
  
  (mkdir -p $output;
   cd $output;
   curl -sSL https://www.nuget.org/api/v2/package/$1/$2 --output tmp.zip;
   unzip -q tmp.zip;
   rm tmp.zip)
}

install_grpc() {
  install_nuget_package Grpc.Tools $GRPC_VERSION
  chmod +x $GRPC_PLUGIN
}

install_protoc() {
  install_nuget_package Google.Protobuf.Tools $PROTOC_VERSION
  
  # Temporary fix for a broken proto in the protobuf tools package
  sed -i 's/--)/-- )/g' $PROTOBUF_TOOLS_ROOT/tools/google/protobuf/timestamp.proto
  chmod +x $PROTOC
}

# Modified to expect it to be present locally...
install_microgenerator() {
  case "$OSTYPE" in
    linux*)
      declare -r RUNTIME=linux-x64
      declare -r EXTENSION=
      ;;
    darwin*)
      echo "Microgenerator not currently supported on MacOSX. Ask jonskeet@ for help."
      exit 1
      ;;
    win* | msys* | cygwin*)
      declare -r RUNTIME=win-x64
      declare -r EXTENSION=.exe
      ;;
    *)
      echo "Unknown OSTYPE: $OSTYPE"
      exit 1
  esac
  
  declare -r GENERATOR_ROOT=$REPO_ROOT/../gapic-generator-csharp  
  export GAPIC_PLUGIN=$GENERATOR_ROOT/Google.Api.Generator/bin/Release/netcoreapp3.1/$RUNTIME/publish/Google.Api.Generator$EXTENSION
  
  (cd $GENERATOR_ROOT; dotnet publish -v quiet -nologo -clp:NoSummary -c Release --self-contained --runtime=$RUNTIME Google.Api.Generator)
}

# Actual entry point

if [[ ! -d ../gapic-generator-csharp ]]
then
  echo 'Expected GAPIC generator to be in ../gapic-generator-csharp'
  exit 1
fi

rm -rf tmp
mkdir tmp
echo 'Cloning googleapis-discovery'
git clone -q https://github.com/googleapis/googleapis-discovery.git --depth=1 tmp/googleapis-discovery
echo 'Cloning googleapis'
git clone -q https://github.com/googleapis/googleapis.git --depth=1 tmp/googleapis

rm tmp/googleapis-discovery/google/cloud/compute/v1/compute_small.proto

install_protoc
install_microgenerator
install_grpc
declare -r CORE_PROTOS_ROOT=$PROTOBUF_TOOLS_ROOT/tools

mkdir -p tmp/client

GOOGLEAPIS=tmp/googleapis
GOOGLEAPIS_DISCOVERY=tmp/googleapis-discovery
API_SRC_DIR=tmp/googleapis-discovery/google/cloud/compute/v1

# TODO: gRPC Service Config
# TODO: Common resources

echo 'Generating messages and services'
# Message and service generation.
$PROTOC \
  --csharp_out=Google.Cloud.Compute.V1/Google.Cloud.Compute.V1 \
  --grpc_out=Google.Cloud.Compute.V1/Google.Cloud.Compute.V1 \
  --plugin=protoc-gen-grpc=$GRPC_PLUGIN \
  -I $GOOGLEAPIS \
  -I $GOOGLEAPIS_DISCOVERY \
  -I $CORE_PROTOS_ROOT \
  $API_SRC_DIR/*.proto \
  2>&1 | grep -v "is unused" || true # Ignore import warnings (and grep exit code)

echo 'Generating clients'

# Client generation. This uses a temporary directory to avoid overwriting
# project files.
$PROTOC \
  --gapic_out=tmp/client \
  --plugin=protoc-gen-gapic=$GAPIC_PLUGIN \
  -I $GOOGLEAPIS \
  -I $GOOGLEAPIS_DISCOVERY \
  -I $CORE_PROTOS_ROOT \
  $API_SRC_DIR/*.proto \
  $COMMON_RESOURCES_PROTO \
  2>&1 | grep -v "is unused" || true # Ignore import warnings (and grep exit code)

# Fix up Grpc.Core parts
# We have a hand-written piece at the moment for the adapter.
sed -i 's/using gaxgrpccore = Google.Api.Gax.Grpc.GrpcCore;//g' tmp/client/Google.Cloud.Compute.V1/*.g.cs
sed -i 's/=> gaxgrpccore::GrpcCoreAdapter.Instance/=> ComputeRestAdapter.ComputeAdapter/g' tmp/client/Google.Cloud.Compute.V1/*.g.cs

cp tmp/client/Google.Cloud.Compute.V1/*.g.cs Google.Cloud.Compute.V1/Google.Cloud.Compute.V1
cp tmp/client/Google.Cloud.Compute.V1.Tests/*.g.cs Google.Cloud.Compute.V1/Google.Cloud.Compute.V1.Tests
cp tmp/client/Google.Cloud.Compute.V1.Snippets/*.g.cs Google.Cloud.Compute.V1/Google.Cloud.Compute.V1.Snippets

