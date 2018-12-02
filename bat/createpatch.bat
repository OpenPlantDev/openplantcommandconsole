@echo off


if [%OP_AppFolder%] == [] goto noAppSet

if [%OP_RepoFolder%] == [] set OP_RepoFolder=%CD%

if not exist %OP_RepoFolder% goto noRepoFolder

set patchExt=patch
pushd %OP_RepoFolder%

rem this gets the current folder name, use it for the patch file name
for %%* in (.) do set patchFileName=%%~nx*
rem echo %patchFileName%

if not exist %patchFileName%.%patchExt% (
set patchFileName=%patchFileName%.%patchExt%
goto patchFileNameOK
)

setlocal enabledelayedexpansion
FOR /L %%I IN (1,1,50) DO (
set tmpPatchFileName=%patchFileName%_%%I.%patchExt%
if not exist !tmpPatchFileName! (
set patchFileName=!tmpPatchFileName!
goto patchFileNameOK
)
)

if exist patchFileName goto unableToPatch


:patchFileNameOK

rem create the patch
echo Creating patch %CD%\%patchFileName%
hg diff -g > %patchFileName%
goto done

:noRepoFolder
echo Repo folder does not exist
goto done


:noAppSet
echo No application set
goto done

:no_RepoFolderSet
echo OP_RepoFolder is not set
goto done

:unableToCreatePatch
echo Unable to create patch, too many patch files exist in %OP_RepoFolder%
goto done

:done
popd
echo done
