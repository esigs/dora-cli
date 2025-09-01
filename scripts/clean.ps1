[CmdletBinding()]
param()

$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$SolutionPath = Join-Path -Path $PSScriptRoot -ChildPath "..\dora-cli.sln" -Resolve

Write-Host "Cleaning dora-cli solution..."
dotnet clean $SolutionPath

Write-Host "Removing publish_output directory..."
$PublishOutputDirectory = Join-Path -Path $PSScriptRoot -ChildPath "..\src\esigs.dora-cli\publish_output" -Resolve
if (Test-Path $PublishOutputDirectory) {
    Remove-Item -Path $PublishOutputDirectory -Recurse -Force
}

Write-Host "Removing nupkg files..."
$NupkgDirectory = Join-Path -Path $PSScriptRoot -ChildPath "..\src\esigs.dora-cli\nupkg" -Resolve
if (Test-Path $NupkgDirectory) {
    Remove-Item -Path (Join-Path $NupkgDirectory "*.nupkg") -Force
}

Write-Host "Clean operation completed."