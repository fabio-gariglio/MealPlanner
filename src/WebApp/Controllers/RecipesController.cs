using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Models;
using WebApp.Contracts;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IIngredientParser _ingredientParser;
        private readonly IMapper _mapper;

        public RecipesController(IRecipeRepository recipeRepository,
            IIngredientParser ingredientParser,
            IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _ingredientParser = ingredientParser;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recipes = await _recipeRepository.GetAllAsync();
            var response = recipes.Select(_mapper.Map<RecipeResponseContract>);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var recipe = await _recipeRepository.GetByIdAsync(id);
            if (recipe == null) return NotFound();

            var response = _mapper.Map<RecipeResponseContract>(recipe);

            return Ok(response);
        }

        [HttpPost("import")]
        public async Task<IActionResult> Import([FromBody] RecipeImportRequest request)
        {
            var recipe = ToRecipe(request);

            await _recipeRepository.InsertAsync(recipe);

            var response = _mapper.Map<RecipeResponseContract>(recipe);
            
            return Ok(response);
        }

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
                Instructions = instructions,
                Servings = request.Servings,
                Preparation = TimeSpan.FromMinutes(request.Preparation)
            };
        }
    }
}
