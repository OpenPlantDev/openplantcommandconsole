if "%OP_APP_PRODUCTNAME%"=="OpenPlantPID" (set primarySchema=OpenPlant) else (set primarySchema=OpenPlant_3D)

set REPORTDEBUG=1
set REPORTSELECT=1

set selecteWorkspace=%OutRoot%Winx64\Product\%OP_APP_OUTPRODUCTFOLDER%\Configuration\WorkSpaces\WorkSpace\
set workSet=OpenPlantImperial
set schemaLoc=%OutRoot%Winx64\Product\%OP_APP_OUTPRODUCTFOLDER%\Configuration\WorkSpaces\WorkSpace\WorkSets\OpenPlantImperial\Standards\OpenPlant\Schemas\;%OutRoot%\Winx64\Product\%OP_APP_OUTPRODUCTFOLDER%\Configuration\WorkSpaces\WorkSpace\Standards\OpenPlant\Schemas\;

echo Running ReportingDesigner.exe -wr%selecteWorkspace% -ws%workSet% -sp%schemaLoc% -ps%primarySchema% -pa%OP_APP_PRODUCTNAME%
%OutRoot%Winx64\Product\%OP_APP_OUTPRODUCTFOLDER%\%OP_APP_PRODUCTNAME%\ReportingDesigner.exe -wr%selecteWorkspace% -ws%workSet% -sp%schemaLoc% -ps%primarySchema%  -pa%OP_APP_PRODUCTNAME% 
