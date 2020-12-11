namespace Persistence.Documents
{
    public class IngredientDocument
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string[] Notes { get; set; }
    }
}
