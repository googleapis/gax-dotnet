@echo on

dotnet restore || goto error

set PROJECTS=src\Google.Api.CommonProtos src\Google.Api.Gax src\Google.Api.Gax.Rest testing\Google.Api.Gax.Testing
set TESTS=test\Google.Api.Gax.Tests test\Google.Api.Gax.Rest.Tests

for %%P in (%PROJECTS%) do (
  echo Building %%P
  dotnet build --version-suffix %PrereleaseTag% --configuration %Configuration% %%P || goto error
)

for %%P in (%TESTS%) do (
  echo Testing %%P
  dotnet test --configuration %Configuration% %%P || goto error
)

for %%P in (%PROJECTS%) do (
  echo Packing %%P
  dotnet pack --version-suffix %PrereleaseTag% --configuration %Configuration% %%P || goto error
)

echo Done!

goto end

:error
echo Build failed due to error.
exit /b 1

:end
