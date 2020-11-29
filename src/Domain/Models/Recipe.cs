using System;

namespace Domain.Models
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Instructions { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public int Servings { get; set; }
        public TimeSpan Preparation { get; set; }
    }
}
