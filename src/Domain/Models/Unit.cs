using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Unit
    {
        public string Name { get; }
        public string Abbreviation { get; }

        public Unit(string name)
        {
            Name = name;
            Abbreviation = null;
        }

        public Unit(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }

        public override string ToString() => Name;

        public static Unit None = new Unit(nameof(None));
        public static Unit Gram = new Unit(nameof(Gram));
        public static Unit Teaspoon = new Unit(nameof(Teaspoon),"tsp");
        public static Unit Tablespoon = new Unit(nameof(Tablespoon), "tbsp");
        public static Unit Cup = new Unit(nameof(Cup));

        private static readonly IDictionary<string, Unit> Mapping =
            new Dictionary<string, Unit>(StringComparer.OrdinalIgnoreCase)
            {
                {nameof(Gram), Gram},
                {nameof(Teaspoon), Teaspoon},
                {nameof(Tablespoon), Tablespoon},
                {nameof(Cup), Cup}
            };

        public static Unit Parse(string name)
        {
            return Mapping.TryGetValue(name, out var result)
                ? result
                : None;

        }
    }
}
