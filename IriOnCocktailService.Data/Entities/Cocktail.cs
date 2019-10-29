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
        public string Pic { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Bar> Bars { get; set; }
        public ICollection<CocktailRating> CocktailRatings { get; set; }
        public ICollection<CocktailComment> CocktailComments { get; set; }
    }
}
