using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace WebApp.Services
{
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
                new Ingredient { Name= "Oats (rolled)", Quantity = new Quantity(3, Unit.Cup) },
                new Ingredient { Name= "Baking Powder", Quantity = new Quantity(1, Unit.Teaspoon) },
                new Ingredient { Name= "Cinnamon", Quantity = new Quantity(1, Unit.Tablespoon) },
                new Ingredient { Name= "Egg", Quantity = new Quantity(1) },
                new Ingredient { Name= "Unsweetened Almond Milk", Quantity = new Quantity(1.5, Unit.Cup) },
                new Ingredient { Name= "Coconut Oil", Quantity = new Quantity(2, Unit.Tablespoon) },
                new Ingredient { Name= "Pomegranate Seeds", Quantity = new Quantity(0.25, Unit.Cup) },
                new Ingredient { Name= "Raspberries", Quantity = new Quantity(0.33, Unit.Cup) },
                new Ingredient { Name= "Pumpkin Seeds", Quantity = new Quantity(0.25, Unit.Cup) },
            },
            Servings = 5,
            Preparation = TimeSpan.FromMinutes(25)
        };

        private readonly IList<Recipe> _recipes = new List<Recipe> { _cinnamonOatmealPancakes };

        public Task<IEnumerable<Recipe>> GetAllAsync()
        {
            return Task.FromResult((IEnumerable<Recipe>) _recipes);
        }

        public Task<Recipe> GetByIdAsync(string id)
        {
            return Task.FromResult(_recipes.FirstOrDefault(r => r.Id == id));
        }

        public Task SaveAsync(Recipe recipe)
        {
            _recipes.Add(recipe);

            return Task.CompletedTask;
        }
    }
}
