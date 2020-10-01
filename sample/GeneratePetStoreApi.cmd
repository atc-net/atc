@ECHO off

CLS
SET currentDirectory=%cd%
FOR %%a IN ("%currentDirectory%") DO SET rootDirectory=%%~dpa
SET srcDirectory=%rootDirectory%src
SET generatorFile=%srcDirectory%\Atc.Rest.ApiGenerator.CLI\bin\Debug\netcoreapp3.1\atc-api.exe

SET projectName=PetStore.Api
SET specUrl=https://raw.githubusercontent.com/OAI/OpenAPI-Specification/master/examples/v3.0/petstore.yaml
SET generatedDirectory=%currentDirectory%\PetStore.Api.Generated

%generatorFile% generate server api -p %projectName% -s %specUrl% -o %generatedDirectory%
