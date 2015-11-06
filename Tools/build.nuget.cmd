@echo off
rem Localization Package
rem set project="%~p0\..\as.Localization\as.Localization\as.Localization.csproj"
rem ..\tools\nuget.exe spec as.Localization.dll.nuspec
set nuspec="as.Localization.nuspec"
..\tools\nuget.exe pack %nuspec%