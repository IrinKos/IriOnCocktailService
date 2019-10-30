using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.Data.Entities
{
    public class CocktailBar
    {
        public string CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }
        public string BarId { get; set; }
        public Bar Bar { get; set; }
    }
}
