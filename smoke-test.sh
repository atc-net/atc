#!/bin/bash

echo "Download Swagger Petstore v3 OpenAPI spec"
curl -O https://petstore3.swagger.io/api/v3/openapi.yaml

echo "Generate code"
cd src/Atc.Rest.ApiGenerator.CLI
dotnet run -- generate server all -p "Swagger Petstore v3" -s ../../openapi.yaml --outputSlnPath ../../petstore/ --outputSrcPath ../../petstore/src --outputTestPath ../../petstore/test -v true
cd ../../
dotnet build ./petstore

rm -rf ./petstore
rm openapi.yaml