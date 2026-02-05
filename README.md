# MenuPlanner (C#)

## Overview

MenuPlanner is a small C# console application that helps users plan weekly meals by storing recipes, generating a weekly menu, and exporting a shopping list. The goal of this module is to demonstrate practical C# skills including data modeling, file I/O, and simple CLI interaction while following the course requirements.

## Module Goals

- Learn and demonstrate idiomatic C# syntax and project structure.
- Implement persistent storage (JSON file) for recipes and menus.
- Provide a simple command-line interface for creating, editing, and exporting menus.
- Produce a 4–5 minute demonstration video documenting implementation and learning outcomes.

## Features

- Add, edit, and remove recipes (name, ingredients, instructions).
- Auto-generate a 7-day weekly menu from available recipes.
- Export shopping list as a text file.
- Save and load project data using JSON files.

## Technology Stack

- Language: C# (targeting .NET 8.0)
- Runtime: .NET SDK 8.0
- Packages: none required (uses `System.Text.Json`)

## Prerequisites

- Install .NET SDK 8.0: https://dotnet.microsoft.com/download
- Git (for publishing to GitHub)

## Build & Run

1. Clone the repository: git clone https://github.com/PiusMukisa/MenuPlanner.git
2. Change directory: cd MenuPlanner
3. Build the project: dotnet build
4. Run the app: dotnet run --project Hello_World.csproj

Example commands (PowerShell):

```powershell
git clone https://github.com/PiusMukisa/MenuPlanner.git
cd MenuPlanner
dotnet build
dotnet run --project Hello_World.csproj
```

## Usage

- Follow the CLI prompts to add recipes, generate a weekly plan, or export a shopping list.
- Data files (recipes.json, menu.json) are stored in the project folder by default.

## Project Structure

- `Program.cs` — application entry point and CLI loop.
- `Models/Recipe.cs` — recipe data model.
- `Services/StorageService.cs` — JSON read/write helpers.
- `Services/MenuGenerator.cs` — logic to generate weekly menus.
- `data/recipes.json` — sample data file (created at runtime).

Adjust paths and namespaces as needed for your implementation.

## Implementation Notes

- The application uses `System.Text.Json` for serialization.
- Input validation is included for basic CLI safety.
- All non-trivial methods are documented with XML comments and inline comments where helpful.

## Demonstration Video

- Create a 4–5 minute video that includes:
	- A short talking-head introduction (required for accreditation).
	- A live demo of adding a recipe, generating a menu, and exporting the shopping list.
	- A brief walkthrough of key code files and what you learned.

- Paste your video URL here when ready:

[Software Demo Video](http://youtube.link.goes.here)

## Sprint Plan (2-week module summary)

- Week 1 (Plan & Build Core): design data models, implement storage, add CLI to create/edit recipes.
- Week 2 (Polish & Demo): implement menu generation, export feature, add comments, create demo video, finalize README.

Estimated effort: 8–10 hours per week (total ~16–20 hours).

## Useful Resources

- Microsoft C# Guide: https://learn.microsoft.com/dotnet/csharp/
- System.Text.Json docs: https://learn.microsoft.com/dotnet/standard/serialization/system-text-json

## Future Work

- Add unit tests for `MenuGenerator` and `StorageService`.
- Implement a GUI (WinForms/MAUI) version.
- Allow ingredient quantities aggregation when exporting shopping lists.

## Repository & Submission

- GitHub repository name: MenuPlanner
- Ensure the repository is public and contains the full source, README, and the video link.

## Author

- Your Name (add your full name here)

## License

- This project is released under the MIT License. See LICENSE for details.