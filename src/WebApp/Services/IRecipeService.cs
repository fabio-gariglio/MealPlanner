using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public interface IRecipeService
    {
        Task<IEnumerable<Recipe>> GetAllAsync();
        Task<Recipe> GetByIdAsync(string id);
    }
}