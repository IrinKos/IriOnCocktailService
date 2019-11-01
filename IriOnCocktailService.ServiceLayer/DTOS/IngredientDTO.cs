using IriOnCocktailService.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class IngredientDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
    }
}
