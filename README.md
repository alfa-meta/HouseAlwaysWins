# The House Always Wins

A small C#/.NET example project that implements card game logic and services for a "house always wins" style demo. It includes a main application in `HouseAlwaysWins` and a test project `HouseAlwaysWins.Tests` with unit tests for models and services.

## Table of Contents

- About
- Features
- Requirements
- Quick start
- Project structure
- Running the app
- Running tests
- Development & contribution
- License

## About

This repository contains a C# solution demonstrating card and hand models, dealer and calculator services, and unit tests to validate behaviour. It's intended as a learning/demo project for .NET development and unit testing practices as well as an introduction to game analysis, and Monte Carlo simulations.

## Features

- Unit tests with xUnit
- Both .NET 8.0 and .NET 9.0 build targets present in the repository outputs

## Requirements

- .NET SDK 8.0 or newer (8.0/9.0 shown in build output). Verify with:
```powershell

dotnet --info

```
## Quick start

1. Open a shell in the repository root (Windows PowerShell recommended).
2. Restore and build the solution:
```powershell

dotnet build

```

3. Run the tests:
```powershell

dotnet test

```

## Project structure (important files)

- `the-house-always-wins.sln` — solution file
- `HouseAlwaysWins/` — main project
  - `HouseAlwaysWins.csproj`
  - `Program.cs`
  - `Controllers/`, `Models/`, `Services/`, `Views/`
- `HouseAlwaysWins.Tests/` — test project using xUnit
  - `HouseAlwaysWins.Tests.csproj`
  - Tests for Models and Services (e.g., `HandTest.cs`, `CardTest.cs`, `CalculatorServiceTest.cs`)
- `LICENSE` — project license

## Running the app

To run the main project from the repo root:

```powershell

dotnet run --project HouseAlwaysWins

```

The project is console-focused (or library) depending on `Program.cs` contents — check `HouseAlwaysWins/Program.cs` for details.
## Running tests

Run all tests:

```powershell

dotnet test

```

Run a single test project:

```powershell

dotnet test HouseAlwaysWins.Tests/HouseAlwaysWins.Tests.csproj

```

Run a single test by name (example):

```powershell

dotnet test --filter FullyQualifiedName~HouseAlwaysWins.Tests.Models.HandTest.SuccessAddCardToHand

```

## Development & contributing

- Follow existing code style in the project. Keep changes small and add tests for new behaviour.
- When adding features, update or add unit tests in `HouseAlwaysWins.Tests`.
- Use `dotnet build` and `dotnet test` before opening a PR.

## License

See `LICENSE` at the project root.