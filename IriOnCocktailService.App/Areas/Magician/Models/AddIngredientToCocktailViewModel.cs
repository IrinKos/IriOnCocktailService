using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class AddIngredientToCocktailViewModel
    {
        public string CocktailId { get; set; }
        public string IngredientId { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
    }
}
