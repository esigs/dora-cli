[CmdletBinding()]
param(
    [Parameter(Mandatory=$false, HelpMessage="Configuration to test (e.g., Debug, Release)")]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Debug"
)

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$SolutionPath = Join-Path -Path $PSScriptRoot -ChildPath ".." -Resolve

Write-Host "Running tests with configuration: $Configuration"
dotnet test "$SolutionPath" --configuration $Configuration
