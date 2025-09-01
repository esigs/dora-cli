# Build and Publishing Scripts

This directory contains PowerShell scripts to automate the build, test, packaging, and publishing processes for the Dora Metrics Tracker project.

## Getting Started

### Prerequisites

*   .NET SDK (Version 9.0 or later recommended)
*   PowerShell

### Building the Project

To build the entire solution, navigate to the project's root directory and run:

```bash
pwsh ./scripts/build.ps1
```

### Running Tests

To execute all unit tests, run the following command from the project's root directory:

```bash
pwsh ./scripts/test.ps1
```

### Packaging

To create NuGet packages for the libraries, run the following command from the project's root directory:

```bash
pwsh ./scripts/pack.ps1
```

The generated `.nupkg` files will be located in `src/esigs.dora.iface/bin/Release/` and `src/esigs.dora.lib/bin/Release/`.

You can specify the build configuration (e.g., `Debug` or `Release`) for all scripts using the `-Configuration` parameter:

```bash
pwsh ./scripts/build.ps1 -Configuration Debug
```

### Publishing NuGet Packages

To publish the NuGet packages to NuGet.org, use the `publish.ps1` script:

```bash
pwsh ./scripts/publish.ps1
```

Before publishing, you need to set the `NUGET_API_KEY` environment variable with your actual NuGet API key.

For example (Linux/macOS):
```bash
export NUGET_API_KEY="YOUR_ACTUAL_API_KEY"
```

For example (Windows Command Prompt):
```cmd
set NUGET_API_KEY="YOUR_ACTUAL_API_KEY"
```

For example (Windows PowerShell):
```powershell
$env:NUGET_API_KEY="YOUR_ACTUAL_API_KEY"
```

Replace `YOUR_ACTUAL_API_KEY` with your actual NuGet API key.

## Versioning

This project uses [Nerdbank.GitVersioning](https://github.com/dotnet/Nerdbank.GitVersioning) for automated version management. The version number is automatically derived from your Git history.

The full version number follows the format `Major.Minor.Patch-gCommitHash`, where:
*   **Major.Minor**: These components are defined in the `version.json` file at the root of the repository.
*   **Patch**: This component is automatically incremented based on the number of commits since the last major.minor version change.
*   **gCommitHash**: This is a short Git commit hash, providing a direct link to the source code that produced the package.

### How to Bump Versions

*   **To bump the Major or Minor version**: Edit the `version.json` file at the root of the repository and update the `version` field (e.g., change `"1.0"` to `"2.0"` for a major bump, or `"1.0"` to `"1.1"` for a minor bump).
*   **Patch versions**: These are automatically handled by `Nerdbank.GitVersioning` with every new commit. You do not need to manually update them.
