namespace Domain.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public Unit Unit { get; set; }
        public string[] Notes { get; set; }

        public override string ToString() => 
            Unit == Unit.None
            ? $"{Quantity} {Name}"
            : $"{Quantity} {Unit} {Name}";
    }
}
