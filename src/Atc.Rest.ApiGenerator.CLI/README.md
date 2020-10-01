# CLI Tool Usage

The Atc.Rest.ApiGenerator.CLI library mentioned above is available through a cross platform command line application.

**Requirements**
- .NET Core 3.1 runtime

## Installation

The tool can be installed as a .NET Core global tool that you can call from the shell / command line

```
dotnet tool install --global atc-api-gen
```

or by following the instructions [here](https://www.nuget.org/packages/atc-api-gen/) to install a specific version of the tool.

A successful installation will output something like:

```
You can invoke the tool using the following command: atc-api
Tool 'atc-api-gen' (version '1.0.104') was successfully installed.`
```

### Usage

Since the tool is published as a .NET Core Tool, it can be launched from anywhere using any command line interface by calling **atc-api**. The help information is displayed using the `--help` argument to **atc-api**

```
$ atc-api --help

Usage: atc-api [command] [options]

Commands
  generate
  validate
```

#### Example for --help on the commands 'generate server api'
```
$ atc-api generate server api --help

Create API project.

Usage: atc-api generate server api [options]

Options:
  --validate-strictMode                    Use strictMode
  --validate-operationIdCasingStyle        Set casingStyle for operationId
  --validate-modelNameCasingStyle          Set casingStyle for model name
  --validate-modelPropertyNameCasingStyle  Set casingStyle for model property name
  -p|--projectPrefixName                   Project prefix name (e.g. 'PetStore' becomes 'PetStore.Api.Generated').
  -o|--outputPath                          Path to generated project.
  --useNullableReferenceTypes              Use nullable reference types in .csproj
  --useAuthorization                       Use authorization
  -v|--verboseMode                         Use verboseMode for more debug/trace information
  --optionsPath                            Path to options json-file.
  -s|--specificationPath                   Path to Open API specification (directory, file, url)
  -?|-h|--help                             Show help information
```


## Usage Examples:

Comming soon...
