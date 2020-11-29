namespace Domain.Models
{
    public class Quantity
    {
        public double Value { get; }
        public Unit Unit { get; }

        public Quantity(double value, Unit unit = Unit.None)
        {
            Value = value;
            Unit = unit;
        }

        public override string ToString() => Unit != Unit.None
            ? $"{Value} {Unit}"
            : Value.ToString();
    }
}
