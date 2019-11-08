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
        public bool IsDeleted { get; set; }

        public virtual ICollection<CocktailIngredientDTO> CocktailIngredients { get; set; } = new List<CocktailIngredientDTO>();
    }
}
