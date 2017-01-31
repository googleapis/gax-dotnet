REM This test takes a long time (~15 minutes)
REM This test uses whatever project is configured in gcloud.

@echo dotnet restore...
dotnet restore
if %errorlevel% neq 0 exit /b %errorlevel%

@echo dotnet build...
dotnet build
if %errorlevel% neq 0 exit /b %errorlevel%

@echo dotnet publish...
dotnet publish -c Release
if %errorlevel% neq 0 exit /b %errorlevel%

pushd bin\Release\netcoreapp1.0\publish

@echo Testing on Google App Engine

@echo runtime: custom>app.yaml
@echo env: flex>>app.yaml
@echo service: platformtest-gae-canbedeleted>>app.yaml

@echo Deploying to GAE, this can take a few minutes...
call gcloud app deploy app.yaml --no-promote --version=integrationtest --quiet
@echo Deployed to GAE.
@echo Accessing test web-page...
for /f %%i in ('powershell.exe "(([System.Text.Encoding]::ASCII.GetString((Invoke-WebRequest https://integrationtest-dot-platformtest-gae-canbedeleted-dot-tryinggce.appspot.com).Content)).Split(\"`n\"))[0]"') do (
  set DETECTED=%%i
)
@echo Deleting GAE service after test, this can take a few minutes...
call gcloud app services delete platformtest-gae-canbedeleted --quiet
@echo GAE service deleted.
@echo Asserting whether test passed.
if /I "%DETECTED%" neq "Gae" (
  echo GAE failed :( not correctly detected, detected as '%DETECTED%'
  popd
  exit /b 1
)
@echo GAE test passed :)
@echo(

@echo Testing on Google Compute Engine

@echo runtime: custom>app.yaml
@echo vm: true>>app.yaml
@echo service: platformtest-gce-canbedeleted>>app.yaml

@echo Deploying to GCE, this can take a few minutes...
call gcloud app deploy app.yaml --no-promote --version=integrationtest --quiet
@echo Deployed to GCE.
@echo Accessing test web-page...
for /f %%i in ('powershell.exe "((Invoke-WebRequest https://integrationtest-dot-platformtest-gce-canbedeleted-dot-tryinggce.appspot.com).Content).Split(\"`n\")[0]"') do (
  set DETECTED=%%i
)
@echo Deleting GCE service after test, this can take a few minutes...
call gcloud app services delete platformtest-gce-canbedeleted --quiet
@echo GCE service deleted.
@echo Asserting whether test passed.
if /I "%DETECTED%" neq "Gce" (
  echo GCE failed :( not correctly detected, detected as '%DETECTED%'
  popd
  exit /b 1
)
@echo GCE test passed :)
@echo(

popd

REM Testing on random machine (not GAE or GCE)
REM This tests on localhost, and assumes localhost is not a GCE machine

@echo Running test locally.
@echo When started, manually browse to http://localhost:5000/
@echo And check that it says "Unknown".
@echo Then type ctrl-C to finish.

dotnet run
