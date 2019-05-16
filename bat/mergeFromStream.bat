@echo off
if /i [%OP_StreamName%] == [] (
    echo OP_StreamName is not set
    goto done
)

if /i [%OP_MergeFromStream%] == [] (
    echo OP_MergeFromStream is not set, will only pull from %OP_StreamName%
    rem goto done
)

echo Merging %OP_MergeFromStream% to %OP_StreamName%
pause

if /i [%OP_StreamName%] == [OpenPlantCurrentPRG] set skipPushValidation=1
if /i [%OP_StreamName%] == [OpenPlantNextPRG] set skipPushValidation=1

cd %SrcRoot%

rem ModelSync
set OP_RepoGroup=modelsync
call mergeRepo ModelSync

rem OpenPlant
if not exist openplant md openplant
cd openplant
set OP_RepoGroup=plant
call mergeRepo Documentation
call mergeRepo ecplugins
call mergeRepo opbimclient
call mergeRepo opcommontools
call mergeRepo opconfiguration
call mergeRepo openplantcore
call mergeRepo openplantproducts
call mergeRepo openplantsupportengineering
call mergeRepo opim
call mergeRepo opom
call mergeRepo oppa
call mergeRepo oppid
call mergeRepo opresources

rem OPEF
if not exist opef md opef
cd opef
call mergeRepo CommonUITools OPEF-CommonUITools
call mergeRepo ElementService OPEF-ElementService
call mergeRepo Geometry OPEF-Geometry
call mergeRepo OPEF
call mergeRepo PlatformComponents OPEF-PlatformComponents
call mergeRepo ProjectComponents OPEF-ProjectComponents
call mergeRepo ProjectDashboard OPEF-ProjectDashboard
call mergeRepo ResourceManager OPEF-ResourceManager
call mergeRepo Tools OPEF-Tools

cd ..

rem Modeler
if not exist Modeler md Modeler
cd Modeler

call mergeRepo openplantframework
call mergeRepo opm
call mergeRepo plantutil
call mergeRepo spectools


cd ..\..


rem buildStrategies (OpenPlantCurrentPRG only)
if /i [%OP_StreamName%] == [OpenPlantCurrentPRG] (
  set OP_RepoGroup=util
  echo merging buildstrategies
  call mergeRepo buildstrategies
)


rem DgnDomains\Plant (OpenPlantCurrentPRG only)
if /i [%OP_StreamName%] == [OpenPlantCurrentPRG] (
    set OP_RepoGroup=plant
    if not exist DgnDomains md DgnDomains
    cd DgnDomains
    call mergeRepo Plant DgnDomains-Plant
    cd ..
)

rem special case for DgnDomains\Plant for OpenPlantNextPRG.
rem We must merge from http://Bim0200.hgbranches.bentley.com/plant/DgnDomains-Plant as there is no stream copy on OpenPlantNextDev
if /i [%OP_StreamName%] == [OpenPlantNextPRG] (
    set OP_RepoGroup=plant
    if not exist DgnDomains md DgnDomains
    cd DgnDomains
    call mergeRepo Plant DgnDomains-Plant http://Bim0200.hgbranches.bentley.com/plant/DgnDomains-Plant
    cd ..
)




:done
echo All Done
pause

