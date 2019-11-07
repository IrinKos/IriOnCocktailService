using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Crawler.Models
{
    public class RatingViewModel
    {
        public string Id { get; set; } //barId
        public string UserId { get; set; }
        [Range(0,5)]
        public decimal Rate { get; set; }
    }
}
