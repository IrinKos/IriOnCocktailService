using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class RatingDTO
    {
        public string BarId { get; set; } //barId/cocktailId
        public string UserId { get; set; }
        [Range(0, 5)]
        public decimal Rate { get; set; }
        public string Name { get; set; }
    }
}
