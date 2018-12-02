@echo off


if [%OP_AppFolder%] == [] goto noAppSet

if [%OP_SrcFolder%] == [] goto no_SrcFolderSet


set NuGetFolder=%OP_SrcFolder%nuget

if not exist %OP_SrcFolder% goto noNuGetFolder

set TMPNuGetFOLDER=nuget-%RANDOM%
pushd %OP_SrcFolder%

if exist %TMPNuGetFOLDER% goto tmpNuGetDirExists

rem rename and delete the NuGet folder
echo renaming %NuGetFolder% to %TMPNuGetFOLDER%
rename %NuGetFolder% %TMPNuGetFOLDER%
echo removing %TMPNuGetFOLDER%
rd %TMPNuGetFOLDER% /s /q
goto done

:tmpNuGetDirExists
echo %TMPNuGetFOLDER% already exists
goto done

:noNuGetFolder
echo nuget folder does not exist
goto done

:noAppSet
echo No application set
goto done

:no_SrcFolderSet
echo OP_SrcFolder is not set
goto done


:done
popd
echo done
