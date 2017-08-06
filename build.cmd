@ECHO OFF

rm -rf dist
rm -rf app/dist
rm -rf api/dist

CD api
dotnet restore
dotnet publish -r win10-x64 --output ..\..\dist\win

CD ..

CD app

CMD /C npm install
CMD /C npm run build


REM Error: spawn C:\Workspace\GitHub\TeBeCo\NuGetPackageExplorerXPlat\dist\win-unpacked\resources\app.asar\api\win\NugetPackageExplorerXPlat.exe ENOENT
