using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class AddCocktailsToBarViewModel
    {
        public string BarId { get; set; }
        public string BarName { get; set; }
        public IEnumerable<SelectListItem> CocktailsToAdd { get; set; }
        public IEnumerable<SelectListItem> CocktailsToRemove { get; set; }
        public List<string> SelectedCocktails { get; set; }
        public List<string> UnSelectedCocktails { get; set; }
    }
}
