using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using WebApp.Contracts;
using WebApp.Services;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;
        private readonly IIngredientParser _ingredientParser;

        public RecipesController(IRecipeService recipeService, IIngredientParser ingredientParser)
        {
            _recipeService = recipeService;
            _ingredientParser = ingredientParser;
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

        [HttpPost("import")]
        public async Task<IActionResult> Import([FromBody] RecipeImportRequest request)
        {
            var recipe = ToRecipe(request);

            await _recipeService.SaveAsync(recipe);

            var response = ToRecipeContract(recipe);

            return Ok(response);
        }

        private static RecipeContract ToRecipeContract(Recipe recipe) => new RecipeContract
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Instructions = recipe.Instructions.ToArray(),
            Ingredients = recipe.Ingredients.Select(ToIngredientContract).ToArray(),
            Servings = recipe.Servings,
            Preparation = recipe.Preparation.TotalMinutes
        };

        private static IngredientContract ToIngredientContract(Ingredient ingredient) => new IngredientContract
        {
            Quantity = ingredient.Quantity?.ToString(),
            Name = ingredient.Name
        };

        private Recipe ToRecipe(RecipeImportRequest request)
        {
            var ingredients = request.IngredientList
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(_ingredientParser.Parse)
                .ToArray();

            var instructions = request.InstructionList
                .Split('\n', StringSplitOptions.RemoveEmptyEntries);

            return new Recipe
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Ingredients = ingredients,
                Instructions = instructions
            };
        }
    }
}
