using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class CommentDTO
    {
        public string BarId { get; set; } //barId/cocktailId
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public string CreatedOn { get; set; }
    }
}
