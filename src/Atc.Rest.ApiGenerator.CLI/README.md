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

## Usage

Since the tool is published as a .NET Core Tool, it can be launched from anywhere using any command line interface by calling **atc-api**. The help information is displayed using the `--help` argument to **atc-api**

```
$ atc-api --help

Copyright (C) 2020 Atc-net

  -n, --projectName    Required. The name of the project.
  -p, --designPath     Required. The path of a yaml file(s).
  -o, --outputPath     Required. The path to place the output.
  --optionsPath        The path to an optional JSON options file.
  --help               Display this help screen.
```

## Usage Examples:

Comming soon...
