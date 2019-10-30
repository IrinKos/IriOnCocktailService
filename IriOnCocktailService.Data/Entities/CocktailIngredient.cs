namespace IriOnCocktailService.Data.Entities
{
    public class CocktailIngredient
    {
        public int Quantity { get; set; }
        public Unit UnitType { get; set; }

        public string CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }

        public string IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
