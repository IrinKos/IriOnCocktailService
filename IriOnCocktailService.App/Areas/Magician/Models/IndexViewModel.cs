using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class IndexViewModel
    {
        public List<BarDTO> Bars { get; set; }
        public List<Cocktail> Cocktails { get; set; }
    }
}
