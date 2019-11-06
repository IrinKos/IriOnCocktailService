using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class CocktailIngredientService
    {
        private readonly IriOnCocktailServiceDbContext context;

        public CocktailIngredientService(IriOnCocktailServiceDbContext context)
        {
            this.context = context;
        }

        //public async Task<CocktailIngredient> CreateCocktailIngredient(string cocktailId, string ingredientId)
        //{
        //    var cocktailIngredient = new CocktailIngredient
        //    {
        //        nam
        //    }
        //}

    }
}
