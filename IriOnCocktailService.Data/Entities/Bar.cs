using System.Collections.Generic;

namespace IriOnCocktailService.Data.Entities
{
    public class Bar
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Cocktail> Cocktails { get; set; }
        public ICollection<BarRating> BarRatings { get; set; }
        public ICollection<BarComment> BarComments { get; set; } 
    }
}