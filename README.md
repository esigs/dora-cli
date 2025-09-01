# DORA CLI

This is a command-line interface (CLI) tool for tracking and managing DORA (DevOps Research and Assessment) metrics.

## Features

*   **Get DORA Metrics:** Retrieve Change Failure Rate, Deployment Frequency, Lead Time for Changes, and Mean Time to Recovery.
*   **Record Deployments:** Log deployment events.
*   **Record Incidents:** Log incident events.

## Installation

The DORA CLI can be installed as a .NET global tool.

### From NuGet.org

Once the `esigs.dora-cli` package is published to NuGet.org, you can install it globally using:

```bash
dotnet tool install --global esigs.dora-cli
```

To install a specific version:

```bash
dotnet tool install --global esigs.dora-cli --version <VERSION_NUMBER>
```

### From Source

To install the tool directly from the source code, first build the project (see [Build Instructions](#build-instructions)). After a successful build, the NuGet package will be located in `src/esigs.dora-cli/bin/Release/`.

Then, install the tool globally using:

```bash
dotnet tool install --global esigs.dora-cli --add-source ./src/esigs.dora-cli/bin/Release/
```

After installation, the tool can be run using the command `esigs-dora`.

## Build Instructions

To build the DORA CLI, you will need:

*   [.NET SDK](https://dotnet.microsoft.com/download) (version 9.0 or later)
*   [PowerShell](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell)

Navigate to the project root directory and run the full build script:

```powershell
pwsh scripts/full-build.ps1
```

This script will clean, build, and pack the CLI application.

## Publish Instructions

To publish the DORA CLI as a NuGet package, you need to set the `NUGET_API_KEY` environment variable with your NuGet API key.

```powershell
$env:NUGET_API_KEY="YOUR_NUGET_API_KEY"
pwsh scripts/publish.ps1
```

The `publish.ps1` script will prompt for confirmation before pushing the package to NuGet.org.

## Usage

Example commands:

*   `esigs-dora get-deployment-frequency`
*   `esigs-dora record-deployment --version 1.0.0 --service my-service`
*   `esigs-dora record-incident --id INC-001 --service my-service --start-time "2025-01-01 10:00" --end-time "2025-01-01 11:00"`
*   `esigs-dora version`

For more details on specific commands and their arguments, run the command with `--help`:

```powershell
esigs-dora get-deployment-frequency --help
```