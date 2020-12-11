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
            
            var ingredient = new Ingredient
            {
                Name = match.Groups["name"].Value,
                Notes = ParseNotes(match.Groups["notes"]),
                Unit = Unit.None,
                Quantity = 0
            };

            if (match.Groups["quantity"].Success)
            {
                ingredient.Unit= ParseUnit(match.Groups["unit"]);
                ingredient.Quantity = ParseQuantity(match.Groups["value"]);
            }

            return ingredient;
        }

        private static double ParseQuantity(Capture capture)
        {
            return capture.Value.Contains("/")
                ? ParseQuantityAsFraction(capture)
                : ParseQuantityAsNumber(capture);
        }

        private static double ParseQuantityAsNumber(Capture capture)
        {
            return double.Parse(capture.Value);
        }

        private static double ParseQuantityAsFraction(Capture capture)
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