rem following are set by OpenPlant Command Console
rem %AppRoot% = Root folder for application source tree
rem %OP_APP_BUILDSTRATEGY% = Application BuildStrategy
rem %TeamName% = TeamName
rem %PP_VER% = PP_VER
rem %ECF_VER% = ECF_VER
rem %DEBUG%
rem BSISRC=%AppRoot%src\
rem BSIOUT=%AppRoot%out\


rem *----------------------------------------------*
rem BuildStrategy specifies how you want to use 
rem Last Known Goods versus building all the source yourself.
rem It also specifies the repositories for the part file.
rem You must have this set.  If you want to build everything
rem in the strategy instead of using any Last Known Goods,
rem you can append ";buildall" to any base strategy.
rem *----------------------------------------------*
set BUILDSTRATEGY=%OP_APP_BUILDSTRATEGY%
if not [%PP_VER%] == [] set BUILDSTRATEGY=%BUILDSTRATEGY%;PowerPlatformLKG.%PP_VER%
if not [%ECF_VER%] == [] set BUILDSTRATEGY=%BUILDSTRATEGY%;ECF_LOCAL_LKG.%ECF_VER%


echo TeamName=%TeamName%
echo App=%OP_APP_DESC%
echo BSISRC=%BSISRC%
echo PP_VER=%PP_VER%
echo ECF_VER=%ECF_VER%
echo DEBUG=%DEBUG%
echo BUILDSTRATEGY=%BUILDSTRATEGY%

rem this is for OPPA (this may have changed and isn't used right now so commenting it out for now.)
rem set OpenPlant=OpenPlant


rem *----------------------------------------------*
rem Some recommended options...
rem *----------------------------------------------*
rem Uncomment here if needed
rem set DXSDK_DIR=c:\dxsdk\
rem set PATH=%PATH%;<python>;<Mercurial>;<CVS>
rem set FxCop0136Path=C:\PROGRA~2\MICROS~1.36\
rem
rem Uncomment here if needed
rem set COMPLUS_MDA=0
rem
rem Building optimized builds
rem set DEBUG=
rem set NDEBUG=1
rem set BUILD_NO_STACK_CHECK=1
rem
rem Use the debugger without triggering the debug heap
rem set _NO_DEBUG_HEAP=1
rem
rem Skip doxygen for DgnPlatform
rem set DONT_BUILD_DOC=1
rem
rem Skip FxCop analysis
rem set SuppressCodeAnalysis=1
rem
rem If you set up tags for your editor...
rem set TAGFILE=%BSISRC%v9.tag

rem *----------------------------------------------*
rem *----------- Shared Shell Setup ---------------*
rem *----------------------------------------------*
call %BSISRC%bsicommon\shell\SharedShellEnv.bat

rem *----------------------------------------------*
rem  Change this to take you to your favorite spot.
rem *----------------------------------------------*
cd /d %SrcRoot%

rem *----------------------------------------------*
rem *NOTICE: MAKE SURE THERE ARE NO SPACES AT      *
rem *        THE END OF YOUR ENV VARS              *
rem *----------------------------------------------*

