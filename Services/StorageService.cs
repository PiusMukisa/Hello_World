using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Hello_World.Models;

namespace Hello_World.Services
{
    /// <summary>
    /// Simple JSON file storage helper using System.Text.Json.
    /// Demonstrates file read/write required by the module.
    /// </summary>
    public static class StorageService
    {
        private const string RecipesFile = "data/recipes.json";

        public static void EnsureDataFolder()
        {
            var dir = Path.GetDirectoryName(RecipesFile);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
        }

        public static void SaveRecipes(List<Recipe> recipes)
        {
            EnsureDataFolder();
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(recipes, options);
            File.WriteAllText(RecipesFile, json);
        }

        public static List<Recipe> LoadRecipes()
        {
            try
            {
                if (!File.Exists(RecipesFile)) return new List<Recipe>();
                var json = File.ReadAllText(RecipesFile);
                return JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
            }
            catch
            {
                return new List<Recipe>();
            }
        }
    }
}
