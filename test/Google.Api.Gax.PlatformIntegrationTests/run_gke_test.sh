projectId=$1

if [ "$projectId" == "" ]; then
    echo "ERROR: Must specify projectId as first parameter"
    exit 1
fi

if [ -z "$2" ]; then
    clusterName="platformintegrationtest"
else
    clusterName=$2
fi

echo
echo "Using project:'$projectId'; cluster:'$clusterName'"
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
command -v kubectl >/dev/null 2>&1
if [ $? -ne 0 ]; then
    echo "ERROR: 'kubectl' missing"
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

echo "Confirming cluster '$clusterName' exists..."
clusterNameCheck="$(gcloud.cmd container clusters list --format='csv(name)' --project=$projectId | grep ^$clusterName$)"
if [ "$clusterNameCheck" != "$clusterName" ]; then
    echo "Request Cluster Name '$clusterName' not found"
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
echo "GKE test"
echo "--------"
echo

export KUBECONFIG="$(pwd)/publish/kubeconfig"
echo "Looking up cluster zone..."
clusterZone=$(gcloud.cmd container clusters list --project=$projectId --filter="name=$clusterName" --format="csv(zone)" | tail -n1)
echo Cluster running in zone: $clusterZone
echo "Building docker image..."
cp Dockerfile ./publish/
imageTag="gcr.io/$projectId/platformintegrationtest"
gcloud.cmd container builds submit ./publish --project=$projectId --tag=$imageTag --timeout=600
if [ $? -ne 0 ]; then
    echo "ERROR: gcloud container builds submit failed"
    exit 1
fi
echo "  ... done"
echo "Retrieving kubernetes credentals..."
gcloud.cmd container clusters get-credentials $clusterName --project=$projectId --zone=$clusterZone
if [ $? -ne 0 ]; then
    echo "ERROR: gcloud container clusters get-credentials failed"
    exit 1
fi
echo "  ... done"

echo "Pre-emptively deleting any old kubernetes service/deployment..."
kubectl delete service platformintegrationtest
kubectl delete deployment platformintegrationtest
echo "  ... done"

echo "kubectl run..."
kubectl run platformintegrationtest --image=$imageTag --port=8080
if [ $? -ne 0 ]; then
    echo "ERROR: kubectl run failed"
    exit 1
fi
echo "  ... done"
kubectl expose deployment platformintegrationtest --port=8080 --type=LoadBalancer
if [ $? -ne 0 ]; then
    echo "ERROR: kubectl expose deployment failed"
    exit 1
fi
echo "  ... done"
echo "Waiting for external IP address to be available..."
ipAddress=""
until [[ "$ipAddress" =~ ^[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+$ ]]; do
    sleep 5
    echo "  ..."
    ipAddress=$(kubectl get services | grep platformintegrationtest | awk '{ print $3 }')
    if [ $? -ne 0 ]; then
        echo "ERROR: kubectl get services failed"
        exit 1
    fi
done
echo "  ... ready, IP: $ipAddress"

url="http://$ipAddress:8080/"
echo "Retrieving test web page: $url"
testResponse=$(curl $url | head -n1)

echo "Deleted kubernetes service/deployment..."
kubectl delete service platformintegrationtest
kubectl delete deployment platformintegrationtest
echo "  ... done"

if [ "$testResponse" != "Gke" ]; then
    echo "FAILED: Test failed, claimed to be platform: $testResponse"
    exit 1
fi

echo "SUCCESS: Test passed, claimed to be platform: $testResponse"
exit 0
