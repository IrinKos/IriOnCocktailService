using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Models
{
    public class IndexViewModel
    {
        public IReadOnlyCollection<BarViewModel> Bars { get; set; }
        public IReadOnlyCollection<CocktailViewModel> Cocktails { get; set; }
    }
}
