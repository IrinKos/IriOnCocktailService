namespace IriOnCocktailService.Data.Entities
{
    public class Comment
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }  

        public string CocktailId { get; set; }
        public Cocktail Cocktail { get; set; }

        public string BarId { get; set; }
        public Bar Bar { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
