# .NET 9.0 Demo App & Unit tests

## Overview

Basic .NET v9.0 application that prints a messgae to stdout on bootstrap and every minute for 2 minutes. The repo also contains basic unit tests of a simple Calculator Class. This project is used to demo building .NET applications using OpenShift Pipelines/Tekton.

## How to use

### Publish a Release of the Project

```bash
dotnet publish ConsoleAppPAC/ConsoleAppPAC.csproj -c Release -o ./publish
```

### Run Unit Tests with Coverage

```bash
dotnet test --collect "XPlat Code Coverage"
```

### Build Image with Podman

```bash
podman build -t dotnet9-demo-app:v0.0.1 .
```

### Run Image with Podman

```bash
podman run dotnet9-demo-app:v0.0.1
```
