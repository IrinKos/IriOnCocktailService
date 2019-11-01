using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class IngredientService
    {
        private readonly IriOnCocktailServiceDbContext context;
        private readonly IDTOMapper<Ingredient, IngredientDTO> mapper;

        //public async Task<IngredientDTO> CreateIngredientDTO(IngredientDTO ingredientDTO)
        //{

        //}
    }
}
