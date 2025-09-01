[CmdletBinding()]
param(
    [Parameter(Mandatory=$false, HelpMessage="Configuration to build (e.g., Debug, Release)")]
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"

Write-Host "Starting full build process..."

# Clean
Write-Host "--- Running Clean ---"
pwsh ./scripts/clean.ps1 -Configuration $Configuration
if ($LASTEXITCODE -ne 0) {
    Write-Error "Clean failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}

# Build
Write-Host "--- Running Build ---"
pwsh ./scripts/build.ps1 -Configuration $Configuration
if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}

# Test
Write-Host "--- Running Test ---"
pwsh ./scripts/test.ps1 -Configuration $Configuration
if ($LASTEXITCODE -ne 0) {
    Write-Error "Tests failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}

# Pack
Write-Host "--- Running Pack ---"
pwsh ./scripts/pack.ps1 -Configuration $Configuration
if ($LASTEXITCODE -ne 0) {
    Write-Error "Pack failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}

# Publish
Write-Host "--- Running Publish ---"
# Note: Publish requires NUGET_API_KEY environment variable to be set
pwsh ./scripts/publish.ps1 -Configuration $Configuration
if ($LASTEXITCODE -ne 0) {
    Write-Error "Publish failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}

Write-Host "Full build process completed successfully."