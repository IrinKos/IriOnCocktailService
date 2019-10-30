using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.Data.Entities
{
    public class Cocktail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
        public bool NotAvailable { get; set; } 

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<CocktailBar> CocktailBars { get; set; }
        public ICollection<CocktailIngredient> CocktailIngredients{ get; set; }
    }
}
