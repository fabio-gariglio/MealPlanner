using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using Domain.Models;
using MongoDB.Driver;
using Persistence.Documents;

namespace Persistence
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<RecipeDocument> _recipes;

        public RecipeRepository(IMongoDatabase database, IMapper mapper)
        {
            _mapper = mapper;
            _recipes = database.GetCollection<RecipeDocument>("Recipes");
        }

        public async Task<Recipe> GetByIdAsync(string recipeId)
        {
            var document = await _recipes
                .Find(x => x.Id == recipeId)
                .FirstOrDefaultAsync();

            return _mapper.Map<Recipe>(document);
        }

        public async Task<IEnumerable<Recipe>> GetAllAsync()
        {
            var documents = await _recipes
                .Find(FilterDefinition<RecipeDocument>.Empty)
                .ToListAsync();

            return documents.Select(_mapper.Map<Recipe>).ToList();
        }

        public async Task InsertAsync(Recipe recipe)
        {
            var document = _mapper.Map<RecipeDocument>(recipe);

            await _recipes
                .InsertOneAsync(document);
        }

        public async Task UpdateAsync(string recipeId, Recipe recipe)
        {
            var document = _mapper.Map<RecipeDocument>(recipe);
            
            await _recipes
                .ReplaceOneAsync(x => x.Id == recipeId, document);
        }
    }
}