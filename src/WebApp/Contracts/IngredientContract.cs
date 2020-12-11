namespace WebApp.Contracts
{
    public class IngredientContract
    {
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
        public string[] Notes { get; set; }
    }
}