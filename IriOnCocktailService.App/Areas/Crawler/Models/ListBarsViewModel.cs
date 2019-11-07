using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Crawler.Models
{
    public class ListBarsViewModel
    {
        public string BarId { get; set; }
        public string BarName { get; set; }
        public string BarPicUrl { get; set; }
        public double? BarRating { get; set; }
        public bool BarNotAvailable { get; set; }
    }
}
