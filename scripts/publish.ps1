[CmdletBinding()]
param(
    [Parameter(Mandatory=$false, HelpMessage="Configuration to publish (e.g., Debug, Release)")]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release",

    [Parameter(Mandatory=$false, HelpMessage="Runtime Identifier (e.g., win-x64, linux-x64)")]
    [string]$RuntimeIdentifier = "linux-x64"
)

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$CliProjectPath = Join-Path -Path $PSScriptRoot -ChildPath "..\src\esigs.dora-cli" -Resolve

Write-Host "Publishing esigs.dora-cli for $RuntimeIdentifier with configuration: $Configuration"
dotnet publish "$CliProjectPath" --configuration $Configuration --runtime $RuntimeIdentifier --self-contained true
