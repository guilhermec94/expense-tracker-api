@echo off
call openapi-generator-cli generate -g aspnetcore -o code -i ..\ExpenseTrackerAPI\ExpenseTrackerApi.yml --additional-properties=aspnetCoreVersion=6.0,operationIsAsync=true,packageName=ExpenseTrackerAPI.CodeGen,packageTitle=Api,useDateTimeOffset=true,operationResultTask=true,pocoModels=true,buildTarget=library,classModifier=abstract,isLibrary=true
rmdir /S /Q ..\ExpenseTrackerAPI.CodeGen\
echo "Copy"
xcopy /Y /E .\code\src\ExpenseTrackerAPI.CodeGen\*.* ..\ExpenseTrackerAPI.CodeGen\
echo "Delete"
rmdir /S /Q .\code
pause