using Domain.Models;
using FluentAssertions;
using NUnit.Framework;

namespace Domain.Tests
{
    public class IngredientParserTests
    {
        private IngredientParser _parser;
        
        [SetUp]
        public void Setup()
        {
            _parser = new IngredientParser();
        }

        [Test]
        public void Parse_converts_a_string_into_ingredient()
        {
            var ingredient = _parser.Parse("1 cup flour");

            ingredient.Should().NotBeNull();
            ingredient.Name.Should().Be("flour");
            ingredient.Quantity.Should().Be(1);
            ingredient.Unit.Should().Be(Unit.Cup);
        }

        [TestCase("1 cup flour", nameof(Unit.Cup))]
        [TestCase("2 cups flour", nameof(Unit.Cup))]
        [TestCase("1 tbsp flour", nameof(Unit.Tablespoon))]
        [TestCase("2 tbsps flour", nameof(Unit.Tablespoon))]
        [TestCase("1 tsp flour", nameof(Unit.Teaspoon))]
        [TestCase("2 tsps flour", nameof(Unit.Teaspoon))]
        [TestCase("1 gram flour", nameof(Unit.Gram))]
        [TestCase("2 grams flour", nameof(Unit.Gram))]
        public void Parse_converts_quantity_unit(string input, string expectedUnit)
        {
            var ingredient = _parser.Parse(input);

            ingredient.Unit.Name.Should().Be(expectedUnit);
        }

        [Test]
        public void Parse_supports_ingredient_without_unit()
        {
            var ingredient = _parser.Parse("1 Onion");

            ingredient.Name.Should().Be("Onion");
            ingredient.Quantity.Should().Be(1);
            ingredient.Unit.Should().Be(Unit.None);
        }

        [Test]
        public void Parse_supports_ingredient_without_quantity()
        {
            var ingredient = _parser.Parse("Sea Salt");

            ingredient.Name.Should().Be("Sea Salt");
            ingredient.Quantity.Should().Be(0);
            ingredient.Unit.Should().Be(Unit.None);
        }

        [Test]
        public void Parse_supports_ingredient_note()
        {
            var ingredient = _parser.Parse("Sea Salt (to taste)");

            ingredient.Name.Should().Be("Sea Salt");
            ingredient.Notes.Should().HaveCount(1);
            ingredient.Notes.Should().Contain("to taste");
        }

        [Test]
        public void Parse_supports_multiple_ingredient_notes_separated_by_comma()
        {
            var ingredient = _parser.Parse("1 Cup Beans (cooked, drained)");

            ingredient.Notes.Should().HaveCount(2);
            ingredient.Notes.Should().Contain("cooked");
            ingredient.Notes.Should().Contain("drained");
        }

        [Test]
        public void Parse_supports_multiple_ingredient_notes_separated_by_conjunction()
        {
            var ingredient = _parser.Parse("1 Cup Beans (drained and rinsed)");

            ingredient.Notes.Should().HaveCount(2);
            ingredient.Notes.Should().Contain("drained");
            ingredient.Notes.Should().Contain("rinsed");
        }

        [TestCase("1/2 Cup Broth", 0.5)]
        [TestCase("1/4 Cup Broth", 0.25)]
        [TestCase("1/3 Cup Broth", 0.33)]
        [TestCase("2/3 Cup Broth", 0.67)]
        public void Parse_converts_quantity_values_expressed_in_ratio_to_number(string input, double expectedValue)
        {
            var ingredient = _parser.Parse(input);

            ingredient.Quantity.Should().Be(expectedValue);
        }
    }
}