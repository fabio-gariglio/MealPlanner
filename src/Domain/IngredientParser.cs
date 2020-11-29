using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Domain.Models;

namespace Domain
{
    public class IngredientParser : IIngredientParser
    {
        private readonly Regex _regex = new Regex(
            @"^(?<quantity>(?<value>\d(\/\d)?)+\s((?<unit>cups?|tbsps?|tsps?|grams?)\s+)?)?(?<name>[^\(]*)(\s+\((?<notes>.*)\))?$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        private readonly Dictionary<string, Unit> _units = new Dictionary<string, Unit>(StringComparer.OrdinalIgnoreCase)
        {
            {"cup",Unit.Cup},
            {"cups",Unit.Cup},
            {"tbsp",Unit.Tablespoon},
            {"tbsps",Unit.Tablespoon},
            {"tsp",Unit.Teaspoon},
            {"tsps",Unit.Teaspoon},
            {"gram",Unit.Gram},
            {"grams",Unit.Gram},
        };

        public Ingredient Parse(string input)
        {
            var match = _regex.Match(input);
            
            return new Ingredient
            {
                Quantity = ParseQuantity(match),
                Name = match.Groups["name"].Value,
                Notes = ParseNotes(match.Groups["notes"]),
            };
        }

        private Quantity ParseQuantity(Match match)
        {
            if (!match.Groups["quantity"].Success) return null;

            var value = ParseValue(match.Groups["value"]);
            var unit = ParseUnit(match.Groups["unit"]);

            return new Quantity(value, unit);
        }

        private static double ParseValue(Capture capture)
        {
            return capture.Value.Contains("/")
                ? ParseValueAsFraction(capture)
                : ParseValueAsNumber(capture);
        }

        private static double ParseValueAsNumber(Capture capture)
        {
            return double.Parse(capture.Value);
        }

        private static double ParseValueAsFraction(Capture capture)
        {
            var numbers = capture.Value.Split('/');
            var numerator = double.Parse(numbers.First());
            var denominator = double.Parse(numbers.Last());

            return Math.Round(numerator / denominator, 2);
        }

        private Unit ParseUnit(Capture capture)
        {
            return _units.TryGetValue(capture.Value, out Unit unit)
                ? unit
                : Unit.None;
        }

        private static string[] ParseNotes(Capture capture)
        {
            return capture.Value.Split(new[] {",", "and"},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(n => n.Trim())
                .ToArray();
        }
    }
}