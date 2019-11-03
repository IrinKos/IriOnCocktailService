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
        public bool IsDeleted { get; set; }
    }
}
