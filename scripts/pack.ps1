[CmdletBinding()]
param(
    [Parameter(Mandatory=$false, HelpMessage="Configuration to build (e.g., Debug, Release)")]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$SolutionPath = Join-Path -Path $PSScriptRoot -ChildPath ".." -Resolve

Write-Host "Packing cli with configuration: $Configuration"
dotnet pack "$SolutionPath/src/esigs.dora-cli/esigs.dora-cli.csproj" --configuration $Configuration --no-build
