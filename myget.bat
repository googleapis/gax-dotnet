@echo on
call dnvm use 1.0.0-rc1-update1 -r clr
IF ERRORLEVEL 1 goto error
call dnu restore
IF ERRORLEVEL 1 goto error


set PROJECTS=src\Google.Api.CommonProtos src\Google.Api.Gax src\Google.Api.Gax.Rest testing\Google.Api.Gax.Testing
set TESTS=test\Google.Api.Gax.Tests test\Google.Api.Gax.Rest.Tests

for %%P in (%PROJECTS%) do (
  echo Building %%P
  call dnu build --configuration %Configuration% %%P
  IF ERRORLEVEL 1 goto error
)

for %%P in (%TESTS%) do (
  echo Testing %%P
  call dnu build --configuration %Configuration% %%P
  IF ERRORLEVEL 1 goto error
  dnx --configuration %Configuration% -p %%P test
  IF ERRORLEVEL 1 goto error
)

for %%P in (%PROJECTS%) do (
  echo Packing %%P
  call dnu pack --configuration %Configuration% %%P
  IF ERRORLEVEL 1 goto error
)

echo Done!

goto end

:error
echo Build failed due to error.
exit /b 1

:end
