# Rayo Templates

This package contains `dotnet new` templates for creating Rayo applications with the published NuGet packages.

## Included templates

- `rayo-desktop`: single-project desktop application
- `rayo-crossplatform`: shared UI library with desktop and Android hosts

## Pack locally

```powershell
dotnet pack Rayo.Templates.csproj -c Release
```

## Uninstall locally

```powershell
dotnet new uninstall Rayo.Templates
```

## Install locally

```powershell
dotnet new install bin\Release\Rayo.Templates.*.nupkg
```

## Create a desktop app

```powershell
dotnet new rayo-desktop -n MyRayoApp
```

## Create a cross-platform app

```powershell
dotnet new rayo-crossplatform -n MyRayoApp
```

## Package version

Generated projects start with `RayoVersion` set to `0.1.8`.

If you want to target another published release, update that property in the generated `.csproj` files.
