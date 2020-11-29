using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe> GetByIdAsync(string id);
        Task SaveAsync(Recipe recipe);
    }
}