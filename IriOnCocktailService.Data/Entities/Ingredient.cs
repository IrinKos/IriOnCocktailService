using System.Collections.Generic;

namespace IriOnCocktailService.Data.Entities
{
    public class Ingredient
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Unit UnitType { get; set; }
        public bool IsDeleted { get; set; } 

        public ICollection<CocktailIngredient> CocktailIngredients { get; set; }
    }
}