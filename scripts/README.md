# Build and Publishing Scripts

This directory contains PowerShell scripts to automate the build, test, packaging, and publishing processes for the Dora CLI project.

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

To create NuGet packages for the CLI, run the following command from the project's root directory:

```bash
pwsh ./scripts/pack.ps1
```

### Publishing

To publish the CLI as a self-contained executable, run the following command from the project's root directory:

```bash
pwsh ./scripts/publish.ps1
```

You can specify the build configuration (e.g., `Debug` or `Release`) for all scripts using the `-Configuration` parameter:

```bash
pwsh ./scripts/build.ps1 -Configuration Debug
```

For publishing, you can also specify the Runtime Identifier:

```bash
pwsh ./scripts/publish.ps1 -RuntimeIdentifier win-x64
```
