@echo off


if [%OP_AppFolder%] == [] goto noAppSet

if [%OP_OutFolder%] == [] goto no_OutFolderSet

if not exist %OP_OutFolder% goto noOutFolder

pushd %OP_OutFolder%..

set TMPOUTFOLDER=out.bak
if not exist %TMPOUTFOLDER% goto tmpFolderOK

setlocal enabledelayedexpansion
FOR /L %%I IN (1,1,25) DO (
set TMPOUTFOLDER=out.bak%%I
if not exist !TMPOUTFOLDER! goto tmpFolderOK
)

if exist %TMPOUTFOLDER% goto unableToCreateTmpFolder


:tmpFolderOK

rem rename and delete the out folder
echo renaming %OP_OutFolder% to %CD%\%TMPOUTFOLDER%
rename %OP_OutFolder% %TMPOUTFOLDER%
goto done

:noOutFolder
echo out folder does not exist
goto done


:noAppSet
echo No application set
goto done

:noOutDirSet
echo OutDir is not set
goto done

:unableToCreateTmpFolder
echo Unable to create out.bak?
goto done

:done
popd
echo done
