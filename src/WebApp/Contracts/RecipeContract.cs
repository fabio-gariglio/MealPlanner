namespace WebApp.Contracts
{
    public class IngredientContract
    {
        public string Quantity { get; set; }
        public string Name { get; set; }
    }

    public class RecipeContract
    {
        public string Name { get; set; }
        public string[] Instructions { get; set; }
        public IngredientContract[] Ingredients { get; set; }
        public string Id { get; internal set; }
        public int Servings { get; internal set; }
        public double Preparation { get; internal set; }
    }
}
