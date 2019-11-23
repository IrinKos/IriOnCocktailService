using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Models
{
    public class CommentViewModel
    {
        public string Id { get; set; } //barId //cocktailId
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        public string CreatedOn { get; set; }
    }
}
