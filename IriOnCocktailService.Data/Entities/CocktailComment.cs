using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.Data.Entities
{
    public class CocktailComment
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }

        public string CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
