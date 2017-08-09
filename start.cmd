@ECHO OFF

rm -rf dist
rm -rf app/dist
rm -rf api/dist

CD api
dotnet restore
REM dotnet publish -r win10-x64 --output ..\..\dist\win
dotnet publish -r win10-x64 --output ..\..\..\app\dist\api\win

CD ..

CD app

REM CMD /C npm install
CMD /C npm run start
