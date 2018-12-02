@echo off


if [%OP_AppFolder%] == [] goto noAppSet

if [%OP_SrcFolder%] == [] goto no_SrcFolderSet


set LKGFolder=%OP_SrcFolder%LastKnownGood

if not exist %OP_SrcFolder% goto noLKGFolder

set TMPLKGFOLDER=LastKnownGood-%RANDOM%
pushd %OP_SrcFolder%

if exist %TMPLKGFOLDER% goto tmpLKGDirExists

rem rename and delete the LKG folder
echo renaming %LKGFolder% to %TMPOUTFOLDER%
rename %LKGFolder% %TMPLKGFOLDER%
echo removing %TMPLKGFOLDER%
rd %TMPLKGFOLDER% /s /q
goto done

:tmpLKGDirExists
echo %TMPLKGFOLDER% already exists
goto done

:noLKGFolder
echo LastKnownGood folder does not exist
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
