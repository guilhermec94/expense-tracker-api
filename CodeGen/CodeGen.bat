@echo off
call openapi-generator-cli generate -g aspnetcore -o code -i ..\ExpenseTracker.API\ExpenseTrackerApi.yml --additional-properties=aspnetCoreVersion=6.0,operationIsAsync=true,packageName=ExpenseTracker.CodeGen,packageTitle=Api,useDateTimeOffset=true,operationResultTask=true,pocoModels=true,buildTarget=library,classModifier=abstract,isLibrary=true
rmdir /S /Q ..\ExpenseTracker.CodeGen\
echo "Copy"
xcopy /Y /E .\code\src\ExpenseTracker.CodeGen\*.* ..\ExpenseTracker.CodeGen\
echo "Delete"
rmdir /S /Q .\code
pause