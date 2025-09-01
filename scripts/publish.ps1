[CmdletBinding()]
param(
    [Parameter(Mandatory=$false, HelpMessage="Configuration to publish (e.g., Debug, Release)")]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",

    [Parameter(Mandatory=$false, HelpMessage="Bypass user confirmation for non-interactive environments.")]
    [switch]$NonInteractive
)

# Grab API key from environment variable
$apiKey = $env:NUGET_API_KEY
if (-not $apiKey) {
    Write-Error "Environment variable NUGET_API_KEY is not set. Exiting."
    exit 1
}

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$SolutionPath = Join-Path -Path $PSScriptRoot -ChildPath ".." -Resolve

Write-Host "Searching for NuGet packages to publish..."

# Automatically find all .nupkg files under src/*/bin/$Configuration
$packages = Get-ChildItem -Path "$SolutionPath/src" -Recurse -Filter "*.nupkg" | Where-Object { $_.FullName -match ".*/bin/$Configuration/" } | Sort-Object LastWriteTime -Descending

if (-not $packages) {
    Write-Warning "No packages found to publish."
    exit 0
}

Write-Host "Found the following packages to publish:"
foreach ($pkg in $packages) {
    Write-Host "  - $($pkg.Name)"
}

if (-not $NonInteractive) {
    $confirm = Read-Host "Do you want to proceed with publishing these packages? (y/n)"
    if ($confirm -ne "y") {
        Write-Host "Publishing cancelled by user."
        exit 0
    }
}

Write-Host "Publishing NuGet packages to default NuGet.org..."

foreach ($pkg in $packages) {
    Write-Host "Pushing $($pkg.FullName)"
    dotnet nuget push $pkg.FullName `
        --source "https://api.nuget.org/v3/index.json" `
        --api-key $apiKey `
        --skip-duplicate `
        --disable-buffering
}

Write-Host "Publishing complete."