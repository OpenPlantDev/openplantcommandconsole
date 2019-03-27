@echo off
if /i [%OP_StreamName%] == [] (
    echo OP_StreamName is not set
    goto done
)

if /i [%OP_MergeFromStream%] == [] (
    echo OP_MergeFromStream is not set
    goto done
)

echo Merging %OP_MergeFromStream% to %OP_StreamName%
pause

cd %SrcRoot%

set OP_RepoGroup=modelsync
call mergeRepo ModelSync


if /i [%OP_StreamName%] == [OpenPlantCurrentPRG] (
    set OP_RepoGroup=plant
    if not exist DgnDomains md DgnDomains
    cd DgnDomains
    call mergeRepo DgnDomains-Plant
    cd ..
)

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
if not exist Modeler md Modeler
cd Modeler

call mergeRepo openplantframework
call mergeRepo opm
call mergeRepo plantutil
call mergeRepo spectools


cd ..\..

if /i [%OP_StreamName%] == [OpenPlantCurrentPRG] (
  echo merging buildstrategies
  call mergeRepo buildstrategies
)

:done
echo All Done
pause

