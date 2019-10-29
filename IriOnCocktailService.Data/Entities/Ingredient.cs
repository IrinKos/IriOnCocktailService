using System.Collections.Generic;

namespace IriOnCocktailService.Data.Entities
{
    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }    
        public ICollection<Cocktail> Cocktails { get; set; }
    }
}