@echo off


if [%OP_AppFolder%] == [] goto noAppSet

if [%OP_OutFolder%] == [] goto no_OutFolderSet

if not exist %OP_OutFolder% goto noOutFolder

set TMPOUTFOLDER=out-%RANDOM%
pushd %OP_OutFolder%..

if exist %TMPOUTFOLDER% goto tmpOutDirExists

rem rename and delete the out folder
echo renaming %OP_OutFolder% to %TMPOUTFOLDER%
rename %OP_OutFolder% %TMPOUTFOLDER%
echo removing %TMPOUTFOLDER%
rd %TMPOUTFOLDER% /s /q
goto done

:tmpOutDirExists
echo %TMPOUTFOLDER% already exists
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

:done
popd
echo done
