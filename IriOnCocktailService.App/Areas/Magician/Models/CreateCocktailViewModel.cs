using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class CreateCocktailViewModel
    {
        public string Id { get; set; } //Cocktail
        public string CocktailName { get; set; }
        public List<AddIngredientToCocktailViewModel> SpecificIngredients { get; set; }
    }
}
