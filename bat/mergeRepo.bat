@echo off

rem Following must be set before calling
rem OP_StreamRemote
rem OP_MergeFromRemote
rem OP_RepoGroup

rem %1 = folder name
rem %2 = repo name

if [%OP_MergeFromRemote%] == [] (
    echo OP_MergeFromRemote not set, pulling from %OP_StreamRemote% only
)


set folderName=%1
set repoName=%2
if [%repoName%] == [] set repoName=%folderName%

echo.
echo.
echo folderName=%folderName%, repoName=%repoName%

IF NOT EXIST %folderName% (
    echo  %folderName% does not exist. Cloning...
    pause
    cd
    rem echo hg clone %OP_StreamRemote%/%OP_RepoGroup%/%repoName%/ %folderName%
    hg clone %OP_StreamRemote%/%OP_RepoGroup%/%repoName%/ %folderName%
    pushd %folderName%
 ) ELSE (
    pushd %folderName%
    cd
    rem echo hg pull %OP_StreamRemote%/%OP_RepoGroup%/%repoName%/
    hg pull -u %OP_StreamRemote%/%OP_RepoGroup%/%repoName%/
 )
 
if [%OP_MergeFromRemote%] == [] (
    goto done
)

cd
rem Check for incoming changes using --bundle, NOTE: hg sets errorlevel to 1 if no changes
rem echo hg incoming %OP_MergeFromRemote%/%OP_RepoGroup%/%repoName%/
hg incoming %OP_MergeFromRemote%/%OP_RepoGroup%/%repoName%/ --bundle incoming.hg
if errorlevel 1 (
    echo No changes found
    goto Done
)

rem use the bundle file if it was created
if exist incoming.hg (
    echo hg pull incoming.hg
    hg pull -u incoming.hg
) else (
    echo hg pull %OP_MergeFromRemote%/%OP_RepoGroup%/%repoName%/
    hg pull -u %OP_MergeFromRemote%/%OP_RepoGroup%/%repoName%/
)

rem skip validation if skipPushValidation is set to 1
if [%skipPushValidation%] == [1] goto doPush

rem check for unresolved or multiple heads, if none go to push. 
echo.
echo ****
echo !!!! Check for unresolved changes or multiple heads !!!!
echo If found run merge in another command shell before proceeding to push
echo.
echo ****
echo.
pause Press any key to proceed to push

:doPush
rem echo hg push
hg push

rem pausing after a push that required a merge, just to allow verification
if unresolved == 1 pause

:done
rem delete the bundle file
if exist incoming.hg del incoming.hg

echo Done
popd
