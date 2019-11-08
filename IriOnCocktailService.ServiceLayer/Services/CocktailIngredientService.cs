using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class CocktailIngredientService : ICocktailIngredientService
    {
        private readonly IriOnCocktailServiceDbContext context;
        private readonly IDTOServiceMapper<CocktailIngredientDTO, CocktailIngredient> cocktailIngredientMapper;

        public CocktailIngredientService(IriOnCocktailServiceDbContext context, IDTOServiceMapper<CocktailIngredientDTO, CocktailIngredient> cocktailIngredientMapper)
        {
            this.context = context;
            this.cocktailIngredientMapper = cocktailIngredientMapper;
        }

        public async Task<List<CocktailIngredientDTO>> CreateCocktailIngredient(List<CocktailIngredientDTO> cocktailIngredientDTOs)
        {
            foreach (var cocktailIngredientDTO in cocktailIngredientDTOs)
            {
                var cocktailIngredient = this.cocktailIngredientMapper.MapFrom(cocktailIngredientDTO);

                await this.context.CocktailIngredients.AddAsync(cocktailIngredient);
            }
            await this.context.SaveChangesAsync();

            return cocktailIngredientDTOs;
        }

    }
}
