#!/bin/bash

set -e

# TODO: Use some appropriate way of determining OS. Ideally, shouldn't need dotnet installed.
#[[ $(dotnet --info | grep "OS Platform" | grep -c Windows) -ne 0 ]] && OS=windows || OS=linux
OS=windows
[[ ${OS} = "windows" ]] && EXE_SUFFIX=.exe || EXE_SUFFIX=

declare -r ROOT=$(realpath $(dirname $0))
cd $ROOT

PROTOBUF_VERSION=3.11.2
GRPC_VERSION=1.22.0
PROTOC=$ROOT/packages/Google.Protobuf.Tools.$PROTOBUF_VERSION/tools/${OS}_x64/protoc${EXE_SUFFIX}
CORE_PROTOS_ROOT=$ROOT/packages/Google.Protobuf.Tools.$PROTOBUF_VERSION/tools
GRPC_PLUGIN=$ROOT/packages/Grpc.Tools.$GRPC_VERSION/tools/windows_x64/grpc_csharp_plugin.exe

# Nuget isn't working nicely for me on Linux...
nuget_install() {
  outdir=packages/$1.$2
  if [ ! -d "$outdir" ]
  then
    echo Fetching $1 version $2
    mkdir -p $outdir
    curl -sSL https://www.nuget.org/api/v2/package/$1/$2 --output tmp.zip
    unzip -q -d $outdir tmp.zip
    if [ -d "packages/$1.$2/tools" ]
    then 
      chmod +x $(find packages/$1.$2/tools -type f)
    fi

    rm tmp.zip
  fi
}

install_dependencies() {
  # Make sure we have all the tools we need.
  # Prerequisite: Java already installed so that gradlew will work
  nuget_install Google.Protobuf.Tools $PROTOBUF_VERSION
  nuget_install Grpc.Tools $GRPC_VERSION

  if [ -d "googleapis" ]
  then
    pushd googleapis > /dev/null
    git pull
    popd > /dev/null
  else
    git clone --recursive  https://github.com/googleapis/googleapis
  fi
}

# Entry point

install_dependencies

declare -r OUTDIR=tmp
declare -r TARGETDIR=Google.Api.CommonProtos
rm -rf $OUTDIR
mkdir $OUTDIR

# Note: not using find for google/api, as it contains
# services, and we don't want those (yet, at least)

$PROTOC \
  -I googleapis \
  -I $CORE_PROTOS_ROOT \
  --csharp_out=$OUTDIR \
  --csharp_opt=base_namespace=Google \
  googleapis/google/api/*.proto \
  googleapis/google/api/experimental/*.proto \
  $(find googleapis/google/rpc -name '*.proto') \
  $(find googleapis/google/type -name '*.proto')
  
for src in $(find tmp -name '*.cs' | sed 's/tmp\///g')
do
  if [[ ! -f $TARGETDIR/$src ]]
  then 
    # New file: use this year
    cat copyright-header.txt | sed "s/MODIFY-YEAR/$(date +%Y)/g" > $TARGETDIR/$src
    cat $OUTDIR/$src >> $TARGETDIR/$src
  else
    # Assume we've got the same size of copyright as before, and preserve it
    head -n $(wc -l < copyright-header.txt) $TARGETDIR/$src > $OUTDIR/header
    cat $OUTDIR/header $OUTDIR/$src > $TARGETDIR/$src
  fi
done

rm -rf $OUTDIR

(cd Google.Api.Gax.Grpc.IntegrationTests;
 $PROTOC --csharp_out=. --grpc_out=. -I. --plugin=protoc-gen-grpc=$GRPC_PLUGIN *.proto)

(cd Google.Api.Gax.Grpc.Tests;
 $PROTOC --csharp_out=. --grpc_out=. -I. --plugin=protoc-gen-grpc=$GRPC_PLUGIN *.proto)
