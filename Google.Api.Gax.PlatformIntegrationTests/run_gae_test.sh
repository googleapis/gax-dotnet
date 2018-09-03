projectId=$1

if [ "$projectId" == "" ]; then
    echo "ERROR: Must specify projectId as parameter"
    exit 1
fi

echo
echo "Using project:'$projectId'"
echo

# Check required commands are installed
echo "Checking required commands are installed..."
command -v dotnet >/dev/null 2>&1
if [ $? -ne 0 ]; then
    echo "ERROR: 'dotnet' missing"
    exit 1
fi
command -v gcloud.cmd >/dev/null 2>&1
if [ $? -ne 0 ]; then
    echo "ERROR: 'gcloud' missing"
    exit 1
fi
echo "  ... all installed OK"

# Check gcloud things are ready for the test
echo "Confirming project '$projectId' exists..."
projectCheck="$(gcloud.cmd projects list --format='csv(project_id)' | grep ^$projectId$)"
if [ "$projectCheck" != "$projectId" ]; then
    echo "ERROR: Requested Project ID '$projectId' not found"
    exit 1
fi
echo "  ... confirmed OK"

echo
echo "Building project"
echo

dotnet restore
if [ $? -ne 0 ]; then
    exit 1
fi

dotnet build
if [ $? -ne 0 ]; then
    exit 1
fi

dotnet publish -c Release -o publish
if [ $? -ne 0 ]; then
    exit 1
fi

echo
echo "GAE test"
echo "--------"
echo

cp Dockerfile ./publish/
cp app.gae.yaml ./publish/app.yaml
cd publish
echo "Deploying to GAE. This can take several minutes..."
gcloud.cmd app deploy app.yaml --no-promote --version=test --quiet --project=$projectId
if [ $? -ne 0 ]; then
    echo "ERROR: gcloud app deploy failed";
    exit 1
fi
echo "  ... deploy done"

url="https://test-dot-platformtest-gae-canbedeleted-dot-$projectId.appspot.com"
echo "Retrieving test web page: $url"
testResponse=$(curl $url | head -n1)
echo "Test response: $testResponse"

echo "Deleting GAE service. This can take a few minutes..."
gcloud.cmd app services delete platformtest-gae-canbedeleted --quiet --project=$projectId
if [ $? -ne 0 ]; then
    echo "ERROR: gcloud app services delete failed";
    exit 1
fi

if [ "$testResponse" != "Gae" ]; then
    echo "FAILED: Test failed, claimed to be platform: $testResponse"
    exit 1
fi

echo "SUCCESS: Test passed, claimed to be platform: $testResponse"
exit 0