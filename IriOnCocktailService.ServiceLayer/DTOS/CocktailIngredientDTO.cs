using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS 
{
    public class CocktailIngredientDTO
    {
        public string CocktailId { get; set; }
        public string IngredientId { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Type { get; set; }
    }
}
