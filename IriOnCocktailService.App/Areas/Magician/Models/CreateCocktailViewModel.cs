using IriOnCocktailService.ServiceLayer.DTOS;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class CreateCocktailViewModel
    {
        public string Id { get; set; } //Cocktail
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string CocktailName { get; set; }
        public string PicUrl { get; set; }
        public List<SelectListItem> AllIngredients { get; set; }
        public List<SelectListItem> AllUnitTypes { get; set; }
        public List<CreateIngredientViewModel> AllAllIngredients { get; set; }
        public List<AddIngredientToCocktailViewModel> SpecificIngredients { get; set; }
    }
}
