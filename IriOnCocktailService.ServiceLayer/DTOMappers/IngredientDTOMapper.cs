using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class IngredientDTOMapper : IDTOServiceMapper<Ingredient, IngredientDTO>,
                                       IDTOServiceMapper<IngredientDTO, Ingredient>
    {
        public IngredientDTO MapFrom(Ingredient entity)
        {
            return new IngredientDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                UnitType = entity.UnitType.ToString(),
                IsDeleted = entity.IsDeleted
            };
        }

        public Ingredient MapFrom(IngredientDTO ingredientDTO)
        {
            return new Ingredient
            {
                Name = ingredientDTO.Name,
                UnitType = (Unit)Enum.Parse(typeof(Unit), ingredientDTO.UnitType)
            };
        }
    }
}
