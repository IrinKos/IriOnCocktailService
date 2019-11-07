using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class BarRatingDTO
    {
        public string BarId { get; set; } //barId
        public string UserId { get; set; }
        [Range(0, 5)]
        public decimal Rate { get; set; }
    }
}
