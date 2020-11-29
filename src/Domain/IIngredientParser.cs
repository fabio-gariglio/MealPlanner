using Domain.Models;

namespace Domain
{
    public interface IIngredientParser
    {
        Ingredient Parse(string input);
    }
}