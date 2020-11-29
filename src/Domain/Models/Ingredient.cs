namespace Domain.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public Quantity Quantity { get; set; }
        public string[] Notes { get; set; }

        public override string ToString() => $"{Quantity} {Name}";
    }
}
