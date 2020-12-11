using System.Linq;
using System.Text;
using AutoMapper;
using Domain.Models;
using WebApp.Contracts;

namespace WebApp
{
    public class WebAppProfile : Profile
    {
        public WebAppProfile()
        {
            CreateMap<Recipe, RecipeResponseContract>()
                .ForMember(
                    contract => contract.PreparationInMinutes,
                    opt => opt.MapFrom(x => x.Preparation.TotalMinutes)
                );

            CreateMap<Ingredient, IngredientContract>()
                .ForMember(
                    contract => contract.Unit,
                    opt => opt.MapFrom(x => x.Unit.ToString())
                );
        }
    }
}
