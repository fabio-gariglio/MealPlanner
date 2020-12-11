namespace WebApp.Contracts
{
    public class RecipeResponseContract
    {
        public string Name { get; set; }
        public string[] Instructions { get; set; }
        public IngredientContract[] Ingredients { get; set; }
        public string Id { get; internal set; }
        public int Servings { get; internal set; }
        public double PreparationInMinutes { get; internal set; }
    }
}
