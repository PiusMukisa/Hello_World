using System;
using System.Collections.Generic;
using Hello_World.Models;

namespace Hello_World.Services
{
    /// <summary>
    /// Generates a weekly menu from available recipes.
    /// Demonstrates loops, conditionals, and simple algorithms.
    /// </summary>
    public static class MenuGenerator
    {
        public static List<Recipe> GenerateWeeklyMenu(List<Recipe> available, int days = 7)
        {
            var menu = new List<Recipe>();
            if (available == null || available.Count == 0) return menu;

            var rand = new Random();
            for (int i = 0; i < days; i++)
            {
                // Choose a random recipe (demonstrates expressions and loops)
                var index = rand.Next(available.Count);
                menu.Add(available[index]);
            }

            return menu;
        }
    }
}
