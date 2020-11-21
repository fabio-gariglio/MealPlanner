using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Contracts;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeService.GetAllAsync();
            var response = recipes.Select(ToRecipeContract).ToArray();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var recipe = await _recipeService.GetByIdAsync(id);
            if (recipe == null) return NotFound();

            var response = ToRecipeContract(recipe);

            return Ok(response);
        }

        private static RecipeContract ToRecipeContract(Recipe recipe) => new RecipeContract
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Instructions = recipe.Instructions.ToArray(),
            Ingredients = recipe.Ingredients.Select(ToIngredientContract).ToArray()
        };

        private static IngredientContract ToIngredientContract(Ingredient ingredient) => new IngredientContract
        {
            Quantity = ingredient.Quantity.ToString(),
            Name = ingredient.Name
        };
    }
}
