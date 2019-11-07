using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class CocktailIngredientDTOMapper : IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO>
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
    }
}
