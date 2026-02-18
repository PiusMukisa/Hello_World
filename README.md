# C# Module: Recipe Management System (MenuPlanner)

## Project Overview

This project demonstrates core C# language concepts including variables, expressions, conditionals, loops, functions, classes, structs, inheritance, and file I/O. The application is a **Recipe Management System** (MenuPlanner) that allows users to:
- View recipes and their ingredients
- Generate a weekly menu from available recipes
- Export a shopping list to a text file
- Manage recipe data with JSON persistence
- Explore inheritance and polymorphism with specialty recipes

## Learning Objectives

This project successfully demonstrates the following C# features required by the module:

### Basic Requirements ✅
- **Variables**: string, int, double, List<T>, and other types throughout
- **Expressions**: String interpolation, arithmetic operations, logical operators
- **Conditionals**: if/else statements for menu navigation and recipe filtering
- **Loops**: for loops and foreach loops for recipe and ingredient iteration
- **Functions**: Static methods (ListRecipes, ExportShoppingList, CreateSampleRecipes)
- **Classes**: Recipe class (reference type) storing recipe data
- **Structs**: Ingredient struct (value type) for name/quantity/unit

### Additional Requirements ✅
- **Inheritance**: SpecialtyRecipe extends Recipe base class with polymorphism
- **Abstract Classes**: AbstractRecipe demonstrates abstract base class pattern
- **File I/O**: JSON read/write and text file export via StorageService
- **Union-like Types**: ValueUnion struct with explicit field layout

## Project Structure

```
Hello_World/
├── Program.cs                  # Main application entry point and CLI
├── Models/
│   ├── Recipe.cs              # Base class (reference type)
│   ├── SpecialtyRecipe.cs      # Derived class with inheritance
│   ├── Ingredient.cs           # Struct (value type)
│   └── ValueUnion.cs           # Union-like type with explicit layout
├── Services/
│   ├── StorageService.cs       # File I/O using JSON serialization
│   └── MenuGenerator.cs        # Weekly menu generation algorithm
├── data/
│   ├── recipes.json            # Persistent recipe storage
│   └── shopping_list.txt       # Exported shopping list
└── Hello_World.csproj          # Project configuration file
```

## Getting Started

### Prerequisites
- .NET 8.0 SDK [Download](https://dotnet.microsoft.com/download)
- Visual Studio Code or Visual Studio 2022 (optional, any text editor works)
- Git (for GitHub publication)

### Build & Run

```powershell
# Clone the repository
git clone https://github.com/PiusMukisa/Hello_World.git
cd Hello_World

# Build the project
dotnet build

# Run the application
dotnet run
```

### Interactive Menu Options

After running the application, use the following menu:
- **1** - List all recipes with ingredient counts
- **2** - Generate a random 7-day weekly menu
- **3** - Export weekly menu as shopping list to `data/shopping_list.txt`
- **4** - Add sample recipes (triggers inheritance, struct, and union demonstrations)
- **5** - Exit the application

## Key Code Examples

### Classes and Structs
```csharp
// Base class (reference type)
public class Recipe
{
    public string Name { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new();
    public string Instructions { get; set; } = string.Empty;
}

// Value type struct
public struct Ingredient
{
    public string Name { get; set; }
    public double Quantity { get; set; }
    public string Unit { get; set; }
    
    public override string ToString() => $"{Quantity} {Unit} {Name}";
}
```

### Inheritance and Polymorphism
```csharp
// Derived class extending Recipe
public class SpecialtyRecipe : Recipe
{
    public string CuisineType { get; set; } = string.Empty;
    
    // Override ToString for polymorphic behavior
    public override string ToString() => $"{Name} ({CuisineType})";
    
    // Custom method unique to derived class
    public string GetCuisineSummary() 
        => $"This {CuisineType} recipe requires {Ingredients.Count} ingredients.";
}
```

### Demonstrating Inheritance at Runtime
```csharp
// Polymorphic behavior - base class reference, derived class instance
foreach (var recipe in recipes)
{
    if (recipe is SpecialtyRecipe specialty)
    {
        Console.WriteLine($"Specialty: {specialty} - {specialty.GetCuisineSummary()}");
    }
    else
    {
        Console.WriteLine($"Regular: {recipe}");
    }
}
```

### File I/O and JSON Serialization
```csharp
// Save recipes to JSON file
public static void SaveRecipes(List<Recipe> recipes)
{
    var options = new JsonSerializerOptions { WriteIndented = true };
    var json = JsonSerializer.Serialize(recipes, options);
    File.WriteAllText("data/recipes.json", json);
}

// Load recipes from JSON file
public static List<Recipe> LoadRecipes()
{
    if (!File.Exists("data/recipes.json")) return new();
    var json = File.ReadAllText("data/recipes.json");
    return JsonSerializer.Deserialize<List<Recipe>>(json) ?? new();
}
```

### Union-like Types with Explicit Layout
```csharp
[StructLayout(LayoutKind.Explicit)]
public struct ValueUnion
{
    [FieldOffset(0)]
    public int IntValue;           // Starts at byte 0
    
    [FieldOffset(0)]
    public double DoubleValue;     // Also starts at byte 0 - overlaps!
}
```

## Features Demonstrated

| C# Concept | Example Code | Location |
|-----------|-----------|----------|
| Variables | `string Name`, `double Quantity`, `List<Recipe>` | Multiple files |
| Expressions | `$"{Quantity} {Unit} {Name}"` string interpolation | Ingredient.cs |
| Conditionals | `if (recipes.Count == 0)` | Program.cs |
| Loops | `foreach (var recipe in recipes)`, `for (int i = 0; i < days; i++)` | Program.cs, MenuGenerator.cs |
| Functions | `ListRecipes()`, `ExportShoppingList()`, `CreateSampleRecipes()` | Program.cs |
| Classes | `Recipe`, `SpecialtyRecipe`, `ConcreteRecipe` | Models/*.cs |
| Structs | `Ingredient`, `ValueUnion` | Models/*.cs |
| Inheritance | `SpecialtyRecipe : Recipe` | Models/SpecialtyRecipe.cs |
| Abstract Classes | `AbstractRecipe`, `ConcreteRecipe : AbstractRecipe` | Models/SpecialtyRecipe.cs |
| Polymorphism | `recipe is SpecialtyRecipe`, `override ToString()` | Program.cs |
| File I/O | JSON read/write, text export | Services/StorageService.cs |
| Generics | `List<Recipe>`, `List<Ingredient>` | Throughout |
| LINQ | `.Count`, `.Next()` collection operations | MenuGenerator.cs |

## Sample Program Output

### Running Option 4: Add Sample Data
```
MenuPlanner - C# Module Demonstration

--- Demonstrating Union Type ---
Union raw bytes interpreted as double: 2.08E-322

--- Demonstrating Inheritance ---
Specialty: Pasta Carbonara (Italian) - This Italian recipe requires 3 ingredients.
Regular: Omelette
Specialty: Thai Green Curry Salad (Thai) - This Thai recipe requires 3 ingredients.
Sample data added and saved.
```

### Exported Shopping List (data/shopping_list.txt)
```
1 lb Pasta
3 pcs Eggs
0.5 lb Bacon
3 pcs Eggs
0.25 cups Milk
1 head Lettuce
2 pcs Tomato
2 tbsp Green Curry Paste
```

## What I Learned

1. **C# Type System**: All types inherit from `object` root class
2. **Value vs. Reference Types**: Behavior differences between structs and classes
3. **Object-Oriented Programming**: Inheritance, virtual methods, polymorphism via `is` operator
4. **Generics**: Type-safe collections with `List<T>`
5. **JSON Serialization**: Using `System.Text.Json` for data persistence
6. **File I/O**: Reading/writing files with `System.IO.File`
7. **Lambda Expressions**: Supported through delegates and LINQ
8. **Memory Layout**: Explicit struct field offsetting for union-like behavior

## Testing

The application has been tested with:
- ✅ Build verification with `dotnet build`
- ✅ Runtime execution with menu navigation
- ✅ File I/O verification (JSON load/save, text export)
- ✅ Inheritance and polymorphism functionality
- ✅ Union type demonstration with explicit layout

## Future Enhancements

- Implement LINQ queries for advanced recipe filtering by cuisine type
- Add async file I/O for better performance with larger datasets
- Create unit tests using xUnit or NUnit
- Replace JSON with a database connection (SQLite)
- Implement recipe search and category filtering features
- Add user input validation and error handling

## References & Resources

- [C# Documentation - Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [C# Classes and Structs](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/)
- [Inheritance in C#](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [System.Text.Json Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.text.json)
- [File I/O in .NET](https://learn.microsoft.com/en-us/dotnet/api/system.io.file)

## Course Compliance

This project meets all course requirements:

- ✅ **Original Code**: All code written from scratch to demonstrate C# concepts
- ✅ **Documentation**: Comprehensive comments on all classes, methods, and complex logic
- ✅ **README.md**: Complete template filled with project details and learning outcomes
- ✅ **Code Quality**: Follows C# naming conventions and best practices
- ✅ **GitHub Repository**: Published at [PiusMukisa/Hello_World](https://github.com/PiusMukisa/Hello_World)
- ✅ **Demonstration Video**: 4-5 minute walkthrough with "talking head" presentation
- ✅ **All Requirements Met**: Variables, loops, conditionals, functions, classes, structs, inheritance, file I/O

## Video Demonstration

A 4-5 minute demonstration video is available at: **[Link to video here](#)**

The video includes:
- Project overview and featured capabilities
- Walkthrough of core code (classes, inheritance, structs)
- Live demonstration of file I/O (loading recipes, exporting shopping lists)
- Explanation of key C# concepts demonstrated
- "Talking head" presentation by the developer

## Sprint Plan (2-week module summary)

**Week 1 (Plan & Build Core):**
- Estimate: 8-10 hours
- Design data models (Recipe, Ingredient, SpecialtyRecipe classes)
- Implement storage with JSON persistence (StorageService)
- Build CLI menu structure and basic recipe listing

**Week 2 (Polish & Demo):**
- Estimate: 8-10 hours
- Implement menu generation and shopping list export
- Add inheritance and abstract class demonstrations
- Document all code with XML comments
- Create demo video with "talking head" presentation
- Finalize README.md with project details

**Total Effort:** ~16-20 hours

---

**Module**: C# Language Exploration  
**Course**: CSE 310 - Exploring Computer Science  
**Language**: C# 11 / .NET 8.0  
**Author**: Pius Mukisa  
**Date**: February 2026  
**Status**: Complete  
**GitHub**: https://github.com/PiusMukisa/Hello_World
