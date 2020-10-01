@ECHO off

CLS
SET currentDirectory=%cd%
FOR %%a IN ("%currentDirectory%") DO SET rootDirectory=%%~dpa
SET srcDirectory=%rootDirectory%src
SET generatorFile=%srcDirectory%\Atc.Rest.ApiGenerator.CLI\bin\Debug\netcoreapp3.1\atc-api.exe

SET projectName=Demo
SET specFile=%currentDirectory%\Demo.ApiDesign\SingleFileVersion\Api.v1.yaml
SET generatedDirectory=%currentDirectory%
SET optionsFile=%currentDirectory%\\Demo.ApiDesign\DelegateApiGeneratorOptions.json

%generatorFile% generate server api -p %projectName% -s %specFile% -o %generatedDirectory% --optionsPath %optionsFile%
