@echo off

rem Build Project

set vs_configuration=Release
set vs_target=Build


set msbuild="%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
set project="%~p0\..\as.Localization\as.Localization.sln"
set SkipShellExtRegistration=1
set EnableNuGetPackageRestore=true

set msbuildparams=/p:Configuration=%vs_configuration% /t:%vs_target% /nologo /v:m

%msbuild% %project% /p:Platform="Any CPU" %msbuildparams%
IF ERRORLEVEL 1 EXIT /B 1
XCOPY ..\as.Localization\as.Localization\bin\Release\*.dll .\lib\
XCOPY ..\as.Localization\as.Localization\bin\Release\*.config .\content\