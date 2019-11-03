using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class IngredientDTOMapper : IDTOServiceMapper<Ingredient, IngredientDTO>
    {
        public IngredientDTO MapFrom(Ingredient entity)
        {
            return new IngredientDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                IsDeleted = entity.IsDeleted
            };
        }
    }
}
