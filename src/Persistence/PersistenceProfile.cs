using System;
using AutoMapper;
using Domain.Models;
using Persistence.Documents;

namespace Persistence
{
    public class PersistenceProfile : Profile
    {
        public PersistenceProfile()
        {
            CreateMap<Recipe, RecipeDocument>();
                //.ForMember(
                //    doc => doc.Preparation,
                //    opt => opt.MapFrom(x => x.Preparation.TotalMinutes)
                //);

            CreateMap<RecipeDocument, Recipe>();
                //.ForMember(
                //    doc => doc.Preparation,
                //    opt => opt.MapFrom(x => TimeSpan.FromMinutes( x.Preparation))
                //);

            CreateMap<Ingredient, IngredientDocument>()
                .ForMember(
                    doc => doc.Unit,
                    opt => opt.MapFrom(x => x.Unit.ToString())
                );

            CreateMap<IngredientDocument, Ingredient>()
                .ForMember(
                    doc => doc.Unit,
                    opt => opt.MapFrom(x => Unit.Parse(x.Unit))
                );
        }
    }
}
