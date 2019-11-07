using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class BarCommentDTO
    {
        public string BarId { get; set; } //barId
        public string UserId { get; set; }
        public string Comment { get; set; }
    }
}
