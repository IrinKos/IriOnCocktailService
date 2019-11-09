using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class CreateIngredientViewModel
    {
        public string Id { get; set; }
        public  string Name { get; set; }
        public string UnitType { get; set; }
        public List<SelectListItem> AllUnitTypes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
