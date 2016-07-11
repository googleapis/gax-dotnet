call dnvm use 1.0.0-rc1-update1 -r clr || goto error
call dnu restore || goto error

set PROJECTS=src\Google.Api.CommonProtos src\Google.Api.Gax src\Google.Api.Gax.Rest testing\Google.Api.Gax.Testing
set TESTS=test\Google.Api.Gax.Tests test\Google.Api.Gax.Rest.Tests

for %%P in (%PROJECTS%) do (
  call dnu build --configuration %Configuration% %%P || goto error
)

for %%P in (%TESTS%) do (
  call dnu build --configuration %Configuration% %%P || goto error
  call dnx --configuration %Configuration% -p %%P test || goto error
)

for %%P in (%PROJECTS%) do (
  call dnu pack --configuration %Configuration% %%P || goto error
)

goto end

:error
echo Build failed due to error. Please address.
exit /b 1

:end
