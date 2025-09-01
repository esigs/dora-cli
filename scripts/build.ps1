[CmdletBinding()]
param(
    [Parameter(Mandatory=$false, HelpMessage="Configuration to build (e.g., Debug, Release)")]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
Write-Host "Building dora-cli solution with configuration: $Configuration"
dotnet build dora-cli.sln --configuration $Configuration
