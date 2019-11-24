using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class IndexMagViewModel 
    {
        public List<DisplayBarsViewModel> Bars { get; set; }
        public List<DisplayCocktailViewModel> Cocktails { get; set; }
    }
}
