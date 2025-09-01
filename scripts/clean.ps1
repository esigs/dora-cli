[CmdletBinding()]
param(
    [Parameter(Mandatory=$false, HelpMessage="Configuration to build (e.g., Debug, Release)")]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$SolutionPath = Join-Path -Path $PSScriptRoot -ChildPath ".." -Resolve

Write-Host "Cleaning solution with configuration: $Configuration"
dotnet clean "$SolutionPath/dora-cli.sln" --configuration $Configuration

# Explicitly remove NuGet package output directories
$cliBinPath = "$SolutionPath/src/esigs.dora-cli/bin/$Configuration"
$cliObjPath = "$SolutionPath/src/esigs.dora-cli/obj/$Configuration"
$cliNupkgPath = "$SolutionPath/src/esigs.dora-cli/nupkg"

if (Test-Path $cliBinPath) {
    Write-Host "Removing bin directory: $cliBinPath"
    Remove-Item -Path $cliBinPath -Recurse -Force
}

if (Test-Path $cliObjPath) {
    Write-Host "Removing obj directory: $cliObjPath"
    Remove-Item -Path $cliObjPath -Recurse -Force
}

if (Test-Path $cliNupkgPath) {
    Write-Host "Removing nupkg directory: $cliNupkgPath"
    Remove-Item -Path $cliNupkgPath -Recurse -Force
}

Write-Host "Clean complete."
