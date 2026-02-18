using System;
using System.Collections.Generic;

namespace Hello_World.Models
{
    /// <summary>
    /// Demonstrates C# inheritance using the base class Recipe.
    /// SpecialtyRecipe extends Recipe by adding a CuisineType property
    /// and an abstract method override pattern.
    /// </summary>
    public class SpecialtyRecipe : Recipe
    {
        // Additional property for derived class
        public string CuisineType { get; set; } = string.Empty;

        public SpecialtyRecipe() { }

        public SpecialtyRecipe(string name, List<Ingredient> ingredients, string instructions, string cuisineType)
            : base(name, ingredients, instructions)
        {
            CuisineType = cuisineType;
        }

        /// <summary>
        /// Override ToString to demonstrate polymorphism.
        /// </summary>
        public override string ToString() => $"{Name} ({CuisineType})";

        /// <summary>
        /// Custom method unique to SpecialtyRecipe.
        /// </summary>
        public string GetCuisineSummary()
        {
            return $"This {CuisineType} recipe requires {Ingredients.Count} ingredients.";
        }
    }

    /// <summary>
    /// An abstract base class example for more advanced inheritance patterns.
    /// </summary>
    public abstract class AbstractRecipe
    {
        public abstract string GetDescription();
        public virtual string GetServing() => "Serves 4";
    }

    /// <summary>
    /// Concrete implementation of AbstractRecipe to demonstrate abstract keyword.
    /// </summary>
    public class ConcreteRecipe : AbstractRecipe
    {
        public string Name { get; set; } = string.Empty;

        public override string GetDescription() => $"Recipe: {Name}";

        // Inherits GetServing() but can override if needed
    }
}
