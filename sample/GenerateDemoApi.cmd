@ECHO off

CLS
SET currentDirectory=%cd%
FOR %%a IN ("%currentDirectory%") DO SET rootDirectory=%%~dpa
SET srcDirectory=%rootDirectory%src
SET generatorFile=%srcDirectory%\Atc.Rest.ApiGenerator.CLI\bin\Debug\netcoreapp3.1\atc-api.exe

SET projectName=Demo.Api
SET specFile=%currentDirectory%\Demo.ApiDesign\SingleFileVersion\Api.v1.yaml
SET generatedDirectory=%currentDirectory%\Demo.Api.Generated
SET optionsFile=%currentDirectory%\\Demo.ApiDesign\ApiGeneratorOptions.json

%generatorFile% -n %projectName% -p %specFile% -o %generatedDirectory% --optionsPath %optionsFile%
