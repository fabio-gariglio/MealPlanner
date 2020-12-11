using System;

namespace Persistence.Documents
{
    public class RecipeDocument
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Instructions { get; set; }
        public IngredientDocument[] Ingredients { get; set; }
        public int Servings { get; set; }
        public TimeSpan Preparation { get; set; }
    }
}
