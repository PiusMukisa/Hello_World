using System;
using System.Collections.Generic;
using System.Linq;
using Hello_World.Models;
using Hello_World.Services;

// Demonstration program for the MenuPlanner module.
// This file intentionally includes examples of variables, expressions,
// conditionals, loops, functions, classes, structs, and file I/O.

Console.WriteLine("MenuPlanner - C# Module Demonstration\n");

// Load recipes from storage
var recipes = StorageService.LoadRecipes();

if (recipes.Count == 0)
{
	Console.WriteLine("No recipes found. Creating sample recipes...");
	recipes = CreateSampleRecipes();
	StorageService.SaveRecipes(recipes);
}

// Main CLI loop (demonstrates loops and conditionals)
while (true)
{
	Console.WriteLine("\nChoose an option:\n1) List recipes\n2) Generate weekly menu\n3) Export shopping list\n4) Add sample data\n5) Exit");
	Console.Write("> ");
	var input = Console.ReadLine();

	if (input == "1")
	{
		ListRecipes(recipes);
	}
	else if (input == "2")
	{
		var menu = MenuGenerator.GenerateWeeklyMenu(recipes);
		Console.WriteLine("\nWeekly Menu:");
		for (int i = 0; i < menu.Count; i++) Console.WriteLine($"Day {i + 1}: {menu[i].Name}");
	}
	else if (input == "3")
	{
		var menu = MenuGenerator.GenerateWeeklyMenu(recipes);
		var list = ExportShoppingList(menu);
		var path = "data/shopping_list.txt";
		System.IO.File.WriteAllLines(path, list);
		Console.WriteLine($"Shopping list exported to {path}");
	}
	else if (input == "4")
	{
		recipes = CreateSampleRecipes();
		StorageService.SaveRecipes(recipes);
		Console.WriteLine("Sample data added and saved.");
	}
	else if (input == "5")
	{
		Console.WriteLine("Goodbye.");
		break;
	}
	else
	{
		Console.WriteLine("Invalid option. Try again.");
	}
}

// Function demonstrating lists, loops, and string manipulation
static void ListRecipes(List<Recipe> recipes)
{
	if (recipes.Count == 0)
	{
		Console.WriteLine("No recipes available.");
		return;
	}

	Console.WriteLine("\nRecipes:");
	int i = 1;
	foreach (var r in recipes)
	{
		Console.WriteLine($"{i++}. {r.Name} - Ingredients: {r.Ingredients.Count}");
	}
}

// Demonstrates functions and file I/O by creating a shopping list
static List<string> ExportShoppingList(List<Recipe> menu)
{
	var items = new List<string>();
	foreach (var recipe in menu)
	{
		foreach (var ing in recipe.Ingredients)
		{
			// Simple aggregation by text (could be improved)
			items.Add(ing.ToString());
		}
	}

	return items;
}

// Demonstrate classes, structs, and use of the union-like ValueUnion
// Also demonstrates inheritance with SpecialtyRecipe extending Recipe
static List<Recipe> CreateSampleRecipes()
{
	var r1 = new SpecialtyRecipe("Pasta Carbonara", new List<Ingredient>
	{
		new Ingredient("Pasta", 1.0, "lb"),
		new Ingredient("Eggs", 3, "pcs"),
		new Ingredient("Bacon", 0.5, "lb")
	}, "Boil pasta. Fry bacon. Mix with eggs off heat.", "Italian");

	var r2 = new Recipe("Omelette", new List<Ingredient>
	{
		new Ingredient("Eggs", 3, "pcs"),
		new Ingredient("Milk", 0.25, "cups")
	}, "Beat eggs with milk. Cook in pan.");

	var r3 = new SpecialtyRecipe("Thai Green Curry Salad", new List<Ingredient>
	{
		new Ingredient("Lettuce", 1, "head"),
		new Ingredient("Tomato", 2, "pcs"),
		new Ingredient("Green Curry Paste", 2, "tbsp")
	}, "Chop and toss with curry dressing.", "Thai");

	// Example of union-like usage (ValueUnion)
	var u = new ValueUnion();
	u.IntValue = 42; // overlaps with DoubleValue

	// Expression that uses union value (demonstration only)
	double unionAsDouble = u.DoubleValue; // may produce a non-sensical double

	// Show that we used the union value (print to demonstrate)
	Console.WriteLine($"\n--- Demonstrating Union Type ---");
	Console.WriteLine($"Union raw bytes interpreted as double: {unionAsDouble}");

	// Demonstrate inheritance: SpecialtyRecipe extends Recipe
	Console.WriteLine($"\n--- Demonstrating Inheritance ---");
	foreach (var recipe in new List<Recipe> { r1, r2, r3 })
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

	return new List<Recipe> { r1, r2, r3 };
}

