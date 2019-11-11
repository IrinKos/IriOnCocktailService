using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class DisplayCocktailViewModel
    {
        public string Name { get; set; }
        public string PictureURL { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
    }
}
