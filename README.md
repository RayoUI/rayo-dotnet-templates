# Rayo Templates

This package contains `dotnet new` templates for creating Rayo applications with the published NuGet packages.

## Included templates

- `rayo-desktop`: single-project desktop application
- `rayo-crossplatform`: shared UI library with desktop and Android hosts
- `rayo-mvvm`: desktop application using Rayo's MVVM and dependency-injection support

## Pack locally

```powershell
dotnet pack Rayo.Templates.csproj -c Release
```

## Publish to NuGet

The publication script sets the package version without modifying the project file. Set
`NUGET_API_KEY` or pass `-ApiKey`; use `-WhatIf` to pack and review the command without publishing.

```powershell
$env:NUGET_API_KEY = "<NuGet API key>"
.\Scripts\Publish-NuGet.ps1 -Version 0.1.10
```

## Publish through GitHub Actions

Use this release script from a clean worktree to create and push a `vX.Y.Z` tag.
The `publish-nuget.yml` GitHub Actions workflow is triggered by that tag and publishes
the package using the repository's configured NuGet credentials.

```powershell
.\Scripts\Publish-GitHubActions.ps1 -Version 0.1.10
```

Use `-Commit <sha-or-ref>` to release a specific commit and `-WhatIf` to review the
operation without creating or pushing a tag.

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

## Create an MVVM app

```powershell
dotnet new rayo-mvvm -n MyRayoApp
```

## Package version

Generated projects start with `RayoVersion` set to `0.1.8`.

If you want to target another published release, update that property in the generated `.csproj` files.
