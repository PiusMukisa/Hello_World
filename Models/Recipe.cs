using System;
using System.Collections.Generic;

namespace Hello_World.Models
{
    /// <summary>
    /// Represents a recipe with a name, ingredients, and instructions.
    /// Demonstrates a C# class (reference type).
    /// </summary>
    public class Recipe
    {
        public string Name { get; set; } = string.Empty;
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public string Instructions { get; set; } = string.Empty;

        public Recipe() { }

        public Recipe(string name, List<Ingredient> ingredients, string instructions)
        {
            Name = name;
            Ingredients = ingredients ?? new List<Ingredient>();
            Instructions = instructions;
        }

        public override string ToString() => Name;
    }
}
