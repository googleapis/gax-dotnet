#!/bin/bash
set -eo pipefail

if [[ "$OSTYPE" == "linux-gnu"* ]]; then OS="linux"; elif [[ "$OSTYPE" == "darwin"* ]]; then OS="darwin"; else OS="windows"; fi

ARCH="amd64"
if [[ "$OS" == "darwin" && $(uname -m) == "arm64" ]]; then
  ARCH="arm64"
fi

echo "Resolving the latest GAPIC Showcase version for $OS-$ARCH..."
SHOWCASE_VERSION=$(curl -s https://api.github.com/repos/googleapis/gapic-showcase/releases/latest | sed -n 's/.*"tag_name": "v\([^"]*\)".*/\1/p')
if [[ -z "$SHOWCASE_VERSION" ]]; then
  echo "Failed to resolve the latest GAPIC Showcase version." >&2
  exit 1
fi

echo "Downloading gapic-showcase-${SHOWCASE_VERSION}-${OS}-${ARCH}..."
curl -sSL -f https://github.com/googleapis/gapic-showcase/releases/download/v${SHOWCASE_VERSION}/gapic-showcase-${SHOWCASE_VERSION}-${OS}-${ARCH}.tar.gz | tar -zx

if [[ "$OS" == "windows" ]]; then
  ./gapic-showcase.exe run --port :7469 --tls &
else
  ./gapic-showcase run --port :7469 --tls &
fi

# Write the PID to a file so the caller can easily tear it down
echo $! > showcase.pid
echo "Showcase started with PID $!"
sleep 2
if ! kill -0 "$!" 2>/dev/null; then
  echo "gapic-showcase failed to start. Please check if port 7469 is already in use." >&2
  exit 1
fi
