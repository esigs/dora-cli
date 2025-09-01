[CmdletBinding()]
param(
    [Parameter(Mandatory=$false, HelpMessage="Configuration to pack (e.g., Debug, Release)")]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$CliProjectPath = Join-Path -Path $PSScriptRoot -ChildPath "..\src\esigs.dora-cli" -Resolve

Write-Host "Packing esigs.dora-cli with configuration: $Configuration"
dotnet pack "$CliProjectPath" --configuration $Configuration --no-build
