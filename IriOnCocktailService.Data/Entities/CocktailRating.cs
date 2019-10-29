using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.Data.Entities
{
    public class CocktailRating
    {
        public string Id { get; set; }
        public decimal Rating { get; set; }

        public string CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
