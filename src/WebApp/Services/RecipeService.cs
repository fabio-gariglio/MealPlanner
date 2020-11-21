using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public abstract class Quantity
    {
    }

    public enum VolumeUnit
    {
        Cup,
        Tablespoon,
        Teaspoon
    }

    public class VolumeQuantity : Quantity
    {
        public double Value { get; set; }
        public VolumeUnit Unit { get; set; }

        public VolumeQuantity(double value, VolumeUnit unit)
        {
            Value = value;
            Unit = unit;
        }

        public override string ToString() => $"{Value} {Unit}";
    }

    public class AbsoluteQuantity : Quantity
    {
        public double Value { get; set; }

        public AbsoluteQuantity(double value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }

    public class Ingredient
    {
        public string Name { get; internal set; }
        public Quantity Quantity { get; internal set; }

        public override string ToString() => $"{Quantity} {Name}";
    }

    public class Recipe
    {
        public string Id { get; internal set; }
        public string Name { get; internal set; }
        public string[] Instructions { get; internal set; }
        public Ingredient[] Ingredients { get; internal set; }
        public int Servings { get; internal set; }
        public TimeSpan Preparation { get; internal set; }
    }

    public class RecipeService : IRecipeService
    {
        private static readonly Recipe _cinnamonOatmealPancakes = new Recipe
        {
            Id = Guid.NewGuid().ToString("N"),
            Name = "Cinnamon Oatmeal Pancakes",
            Instructions = new[] {
                "In a food processor, process the rolled oats until it creates a ﬂour-like consistency. Add the baking powder and cinnamon and pulse to combine.",
                "Add the egg, almond milk and half of the coconut oil to the oat mixture and process until well combined.",
                "Add the remaining coconut oil to a large skillet and place over medium heat. Once hot, pour the batter into skillet the to form one pancake about 3-inches wide.",
                "Once small holes begin to appear in the surface of the pancake, ﬂip over. Cook each side approximately 3 to 4 minutes. Repeat until the batter is ﬁnished.",
                "Top the pancakes with pomegranate seeds, raspberries and pumpkin seeds. Enjoy!"
            },
            Ingredients = new[]
            {
                new Ingredient { Name= "Oats (rolled)", Quantity = new VolumeQuantity(3, VolumeUnit.Cup) },
                new Ingredient { Name= "Baking Powder", Quantity = new VolumeQuantity(1, VolumeUnit.Teaspoon) },
                new Ingredient { Name= "Cinnamon", Quantity = new VolumeQuantity(1, VolumeUnit.Tablespoon) },
                new Ingredient { Name= "Egg", Quantity = new AbsoluteQuantity(1) },
                new Ingredient { Name= "Unsweetened Almond Milk", Quantity = new VolumeQuantity(1.5, VolumeUnit.Cup) },
                new Ingredient { Name= "Coconut Oil", Quantity = new VolumeQuantity(2, VolumeUnit.Tablespoon) },
                new Ingredient { Name= "Pomegranate Seeds", Quantity = new VolumeQuantity(0.25, VolumeUnit.Cup) },
                new Ingredient { Name= "Raspberries", Quantity = new VolumeQuantity(0.33, VolumeUnit.Cup) },
                new Ingredient { Name= "Pumpkin Seeds", Quantity = new VolumeQuantity(0.25, VolumeUnit.Cup) },
            },
            Servings = 5,
            Preparation = TimeSpan.FromMinutes(25)
        };

        private readonly IEnumerable<Recipe> _recipes = new Recipe[] { _cinnamonOatmealPancakes };

        public Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return Task.FromResult(_recipes);
        }

        public Task<Recipe> GetByIdAsync(string id)
        {
            return Task.FromResult(_recipes.FirstOrDefault(r => r.Id == id));
        }
    }
}
