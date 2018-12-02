@echo off


if [%OP_SrcFolder%] == [] goto noAppSet

if [%OP_SeedSrcFolder%] == [] goto no_SeedFolderSet

echo Seeding happens here

set xcopyArgs=/E /I /Q /H /J

SETLOCAL ENABLEDELAYEDEXPANSION
rem unfortunately I can't get this to work for CVS repositories (move away error) so can't add bin folder
for %%X in (libsrc miscdev thirdparty util sdkdistribution sdksources nuget) do (
    set seedFolder=%OP_SeedSrcFolder%%%X
    set srcFolder=%OP_SrcFolder%%%X
    if not exist "!seedFolder!" (
        echo seed folder "!seedFolder!" not found
    ) else if not exist "!srcFolder!" (
        echo xcopy "!seedFolder!" "!srcFolder!" %xcopyArgs%
        xcopy "!seedFolder!" "!srcFolder!" %xcopyArgs%
    ) else echo source folder "!srcFolder!" already exists
)

rem unfortunately I can't get this to work for CVS repositories (move away error) so can't add catalogsandspecs and openplantbin folders
for %%X in (opconfiguration) do (
    set seedFolder=%OP_SeedSrcFolder%openplant\%%X
    set srcFolder=%OP_SrcFolder%openplant\%%X
    if not exist "!seedFolder!" (
        echo seed folder "!seedFolder!" not found
    ) else if not exist "!srcFolder!" (
        echo xcopy "!seedFolder!" "!srcFolder!" %xcopyArgs%
        xcopy "!seedFolder!" "!srcFolder!" %xcopyArgs%
    ) else echo source folder "!srcFolder!" already exists
)

goto done

:noAppSet
echo No application set
goto done

:no_SeedFolderSet
echo OP_SeedSrcFolder is not set
goto done

:done
popd
echo done
