# $env:NUGET_API_KEY = "<tu-api-key>"
# .\Scripts\Publish-NuGet.ps1 -Version 0.1.10

[CmdletBinding(SupportsShouldProcess)]
param(
    [Parameter(Mandatory)]
    [ValidatePattern('^\d+\.\d+\.\d+(?:-[0-9A-Za-z][0-9A-Za-z.-]*)?(?:\+[0-9A-Za-z.-]+)?$')]
    [string]$Version,

    [string]$ApiKey = $env:NUGET_API_KEY,

    [string]$Source = 'https://api.nuget.org/v3/index.json',

    [switch]$SkipDuplicate
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$repositoryRoot = Split-Path -Parent $PSScriptRoot
$projectPath = Join-Path $repositoryRoot 'Rayo.Templates.csproj'
$nuGetConfigPath = Join-Path $repositoryRoot 'NuGet.Config'
$outputDirectory = Join-Path $repositoryRoot (Join-Path 'artifacts\nuget' $Version)

if (-not (Test-Path -LiteralPath $projectPath))
{
    throw "Template project was not found: $projectPath"
}

if (-not (Test-Path -LiteralPath $nuGetConfigPath))
{
    throw "NuGet configuration was not found: $nuGetConfigPath"
}

New-Item -ItemType Directory -Path $outputDirectory -Force -WhatIf:$false | Out-Null

Write-Host "Packing Rayo.Templates $Version..."
& dotnet pack $projectPath -c Release --configfile $nuGetConfigPath --nologo `
    -o $outputDirectory "-p:PackageVersion=$Version"
if ($LASTEXITCODE -ne 0)
{
    throw "dotnet pack failed with exit code $LASTEXITCODE."
}

$packagePath = Join-Path $outputDirectory "Rayo.Templates.$Version.nupkg"
if (-not (Test-Path -LiteralPath $packagePath))
{
    throw "Expected package was not created: $packagePath"
}

if (-not $PSCmdlet.ShouldProcess($packagePath, "publish to $Source"))
{
    return
}

if ([string]::IsNullOrWhiteSpace($ApiKey))
{
    $ApiKey = Read-Host -Prompt 'NuGet API key' -AsSecureString |
        ConvertFrom-SecureString -AsPlainText
}

if ([string]::IsNullOrWhiteSpace($ApiKey))
{
    throw 'A NuGet API key is required. Pass -ApiKey or set the NUGET_API_KEY environment variable.'
}

$pushArguments = @(
    'nuget', 'push', $packagePath,
    '--api-key', $ApiKey,
    '--source', $Source
)

if ($SkipDuplicate)
{
    $pushArguments += '--skip-duplicate'
}

Write-Host "Publishing $packagePath..."
& dotnet @pushArguments
if ($LASTEXITCODE -ne 0)
{
    throw "dotnet nuget push failed with exit code $LASTEXITCODE."
}

Write-Host "Published Rayo.Templates $Version."
