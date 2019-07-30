@echo off

rem Following must be set before calling
rem OP_StreamRemote
rem OP_MergeFromRemote
rem OP_RepoGroup

rem %1 = folder name
rem %2 = repo name
rem %3 = alternative merge from remote repository, currently needed for DgnDomains/Plant on NextPRG

set folderName=%1
set repoName=%2
if [%repoName%] == [] set repoName=%folderName%
set mergeFromRemote=%3
if [%mergeFromRemote%] == [] (
    if not [%OP_MergeFromRemote%] == [] set mergeFromRemote=%OP_MergeFromRemote%/%OP_RepoGroup%/%repoName%/
)

echo.
echo.
echo folderName=%folderName%, repoName=%repoName%
echo mergeFromRemote=%mergeFromRemote%
rem pause

if [%mergeFromRemote%] == [] (
    echo OP_MergeFromRemote not set, pulling from %OP_StreamRemote% only
)


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
 
if [%mergeFromRemote%] == [] (
    goto done
)

cd
rem Check for incoming changes using --bundle, NOTE: hg sets errorlevel to 1 if no changes
rem echo hg incoming %mergeFromRemote%
hg incoming %mergeFromRemote% --bundle incoming.hg
if errorlevel 1 (
    echo No changes found
    goto Done
)

echo Changes found
rem goto Done

rem use the bundle file if it was created
if exist incoming.hg (
    echo hg pull incoming.hg
    hg pull -u incoming.hg
) else (
    echo hg pull %mergeFromRemote%
    hg pull -u %mergeFromRemote%
)

rem skip validation if skipPushValidation is set to 1
if [%skipPushValidation%] == [1] goto doPush

rem check for unresolved or multiple heads, if none go to push. 
echo.
echo ****
echo !!!! Check for unresolved changes or multiple heads !!!!
echo If found, open another command shell and run 
echo hg merge (if necessary, resolve any conflicts)
echo hg commit -m"Merge"
echo return to this command shell and press any key to contiue with the push
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
