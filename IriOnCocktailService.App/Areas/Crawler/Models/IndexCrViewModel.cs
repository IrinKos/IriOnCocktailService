using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Crawler.Models
{
    public class IndexCrViewModel
    {
        public IReadOnlyCollection<BarCrViewModel> Bars { get; set; }
        public IReadOnlyCollection<CocktailCrViewModel> Cocktails { get; set; }
    }
}
