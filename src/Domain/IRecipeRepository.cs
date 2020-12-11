using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetByIdAsync(string recipeId);
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task InsertAsync(Recipe recipe);
        Task UpdateAsync(string recipeId, Recipe recipe);
    }
}