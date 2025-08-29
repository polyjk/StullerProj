# Pokemon Type Effectiveness Console App

A simple C# console application that uses https://pokeapi.co/ to determine a given Pokemon’s type strengths and weaknesses.

## Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

---

## Running the Console App

### 1️ - Build & Run
From the repository root, run:

```bash
dotnet run --project PokemonApp
```
---

### 2️ - Interacting With the App
- When prompted, **enter a Pokemon name** (e.g. `pikachu`, `bulbasaur`, `charmander`).
- The app will:
  - Fetch the Pokemon’s **type(s)** from the Poke API.
  - Display the Pokemon’s **strengths** (types it is effective against).
  - Display the Pokemon’s **weaknesses** (types it is vulnerable to).

---

### 3️ - Example Session

```text
====================================================
 Pokemon Type Effectiveness Calculator
====================================================

Enter Pokemon name: charmander

====================================================
 Results for: CHARMANDER
====================================================

Type: fire
----------------------------
STRONG VS:
  - grass
  - bug
  - ice
  - steel

WEAK VS:
  - water
  - rock
  - ground
```

---

### 4 - Tips
- Input is **case-insensitive**: `Pikachu`, `pikachu`, or `PIKACHU` all work.
- If you enter an invalid name, you’ll see a friendly error message, e.g.:

```text
Error: Unable to fetch Pokemon. It may not exist or the network is unavailable.
```

- The app will keep prompting for new Pokemon until you exit with **Ctrl+C**.

---

## Running Tests

Run the NUnit tests with:

```bash
dotnet test
```

This will discover and run all tests in the `PokemonApp.Tests` project.

---

## Example Test Output

```text
Test run for /mnt/c/CODE/StullerProj/PokemonAppTests/bin/Debug/net8.0/PokemonAppTests.dll (.NETCoreApp,Version=v8.0)
VSTest version 17.11.1 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 16 ms - PokemonAppTests.dll (net8.0)
```
---
<br>

# *Project Notes*

## Design Decisions
- **Dependency Injection**: The app wires up dependencies, This makes the app easier to extend, test, and maintain while allowing for different implementations of Core Interfaces (`IPokemonService`, `ITypeEffectivenessCalc`) if needed.
- **DTOs**: DTOs map directly to API responses, allowing you to query specific properties you want from an API endpoint.


## Challenges Faced
- **Duplicate Entries**: Ensuring types are not repeated in strengths/weaknesses by using sets (`HashSet`).
- **Error Handling**: Looking for points of failure and displaying user-friendly errors.
- **TDD**: Attempted to do test-driven development for a change but felt slower, in the end opted out of it.

## Possible Future Improvements
- Allow multiple pokemon input, for battles or direct comparisons. Would require a lot more calculations in the event a pokemon with two types has double * double weakness from an attack etc.
- Better NUnit Tests, built simple validation tests for core business logic.


