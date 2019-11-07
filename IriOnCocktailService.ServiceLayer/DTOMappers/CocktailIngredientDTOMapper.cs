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
                CocktailId = entity.CocktailId,
                IngredientId = entity.IngredientId,
                Quantity = entity.Quantity,
                UnitType = entity.UnitType.ToString()
            };

        }

        public CocktailIngredient MapFrom(CocktailIngredientDTO cocktailIngredientDTO)
        {
            return new CocktailIngredient
            {
                CocktailId = cocktailIngredientDTO.CocktailId,
                IngredientId = cocktailIngredientDTO.IngredientId,
                Quantity = cocktailIngredientDTO.Quantity,
                UnitType = (Unit)Enum.Parse(typeof(Unit), cocktailIngredientDTO.UnitType)
            };
        }
    }
}
