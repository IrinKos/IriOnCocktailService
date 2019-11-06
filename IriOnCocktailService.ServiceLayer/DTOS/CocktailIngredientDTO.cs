using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS 
{
    class CocktailIngredientDTO
    {
        public int Quantity { get; set; }
        public string UnitType { get; set; }
            
        public string CocktailId { get; set; }
        public string IngredientId { get; set; }
    }
}
