namespace WebApp.Contracts
{
    public class RecipeImportRequest
    {
        public string Name { get; set; }
        public int Servings { get; set; }
        public int Preparation { get; set; }
        public string IngredientList { get; set; }
        public string InstructionList { get; set; }
    }
}
