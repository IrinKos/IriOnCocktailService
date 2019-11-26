using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Models
{
    public class DeleteCocktailViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public bool Deleted { get; set; }
    }
}
