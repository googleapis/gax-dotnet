call dnvm use 1.0.0-rc1-update1 -r clr
IF ERRORLEVEL 1 EXIT /B 1
call dnu restore
IF ERRORLEVEL 1 EXIT /B 1
call dnu build src\Google.Api.Gax
IF ERRORLEVEL 1 EXIT /B 1
call dnu build src\Google.Api.Gax.Rest
IF ERRORLEVEL 1 EXIT /B 1
call dnu build testing\Google.Api.Gax.Testing
IF ERRORLEVEL 1 EXIT /B 1
call dnu build test\Google.Api.Gax.Tests
IF ERRORLEVEL 1 EXIT /B 1
call dnu build test\Google.Api.Gax.Rest.Tests
IF ERRORLEVEL 1 EXIT /B 1
call dnx -p test\Google.Api.Gax.Tests test
IF ERRORLEVEL 1 EXIT /B 1
call dnx -p test\Google.Api.Gax.Rest.Tests test
IF ERRORLEVEL 1 EXIT /B 1
call dnu pack src\Google.Api.Gax
IF ERRORLEVEL 1 EXIT /B 1
call dnu pack src\Google.Api.Gax.Rest
IF ERRORLEVEL 1 EXIT /B 1
call dnu pack testing\Google.Api.Gax.Testing
IF ERRORLEVEL 1 EXIT /B 1
