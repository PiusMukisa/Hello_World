using System;

namespace Hello_World.Models
{
    /// <summary>
    /// A simple value type representing an ingredient.
    /// Demonstrates a C# `struct` (value type).
    /// </summary>
    public struct Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }

        public override string ToString() => $"{Quantity} {Unit} {Name}";
    }
}
