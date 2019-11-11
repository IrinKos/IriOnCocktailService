using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class CocktailIngredientDTOMapper : IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO>,
                                               IDTOServiceMapper<CocktailIngredientDTO, CocktailIngredient>
    {
        public CocktailIngredientDTO MapFrom(CocktailIngredient entity)
        {
            return new CocktailIngredientDTO
            {
                Name=entity.Ingredient.Name,
                Type=entity.Ingredient.UnitType.ToString(),
                CocktailId = entity.CocktailId,
                IngredientId = entity.IngredientId,
                Quantity = entity.Quantity
            };

        }

        public CocktailIngredient MapFrom(CocktailIngredientDTO cocktailIngredientDTO)
        {
            return new CocktailIngredient
            {
                CocktailId = cocktailIngredientDTO.CocktailId,
                IngredientId = cocktailIngredientDTO.IngredientId,
                Quantity = cocktailIngredientDTO.Quantity
            };
        }
    }
}
