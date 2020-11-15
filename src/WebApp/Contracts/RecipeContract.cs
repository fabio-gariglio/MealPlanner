namespace WebApp.Contracts
{
    public class RecipeContract
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public string[] Ingredients { get; set; }
        public object Id { get; internal set; }
    }
}
