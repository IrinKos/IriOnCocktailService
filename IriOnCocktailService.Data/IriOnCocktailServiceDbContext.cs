using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IriOnCocktailService.Data
{
    public class IriOnCocktailServiceDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        private readonly List<Ingredient> ingredientSeader = new List<Ingredient>()
        {
            new Ingredient() {Id = "dcb14d4d-6329-4641-bdd1-b02b7174ddcf", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Vodka"},
            new Ingredient() {Id = "2a34f05b-192a-46be-986a-3f23afa66a65", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Tequila" },
            new Ingredient() {Id = "cf9db0c7-b266-4238-9b14-2e0b89cda8ef", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Gin" },
            new Ingredient() {Id = "9dc9533e-6aa5-4483-8613-e7160a17547d", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Tonik" },
            new Ingredient() {Id = "f99c65e7-fb0b-4723-a3d5-8ac05a8ba1e4", IsDeleted = false, UnitType = Unit.Millilitres, Name = "CocaCola" },
            new Ingredient() {Id = "a69c54ff-8e93-4181-8998-b4de42304075", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Soda" },
            new Ingredient() {Id = "6fe3620d-87be-4773-90c1-d0a072f0c838", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Wiskey" },
            new Ingredient() {Id = "b96ae8b3-7fad-406c-97d2-bc5e6dcc0d8c", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Red Bull" },
            new Ingredient() {Id = "07ee6b8c-8986-4886-bbfd-cdca6e52a5df", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Water" },
            new Ingredient() {Id = "d82e5701-27e5-45a2-955d-01d1071fce02", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Banana Juice" },
            new Ingredient() {Id = "44ebac14-88ca-404f-87e6-ee0f3d3c180e", IsDeleted = false, UnitType = Unit.Millilitres, Name = "Orange Juice" },
            new Ingredient() {Id = "3fea7311-64e6-4325-af27-28cb41a5cf2c", IsDeleted = false, UnitType = Unit.Grams, Name = "Salt" },
            new Ingredient() {Id = "6852531d-f7ca-4c05-8b02-019a3ac53737", IsDeleted = false, UnitType = Unit.Grams, Name = "Cinnamon" },
            new Ingredient() {Id = "00b7970b-96e4-49ee-97c0-896871d4bd9f", IsDeleted = false, UnitType = Unit.Quantity, Name = "Ice" },
            new Ingredient() {Id = "6e3634b2-518f-40e2-ac20-1bf56297364a", IsDeleted = false, UnitType = Unit.Quantity, Name = "Olive" }
        };

        //private List<Bar> barSeader = new List<Bar>()
        //{
        //    new Bar() {Id = "56d9e733-b150-45c4-8b87-f5a5e31bc23b", Name = "Camino Piano Bar", Address = "Neofit Rilski 70 str.", PhoneNumber = "089 912 1219", PicUrl = "https://www.bar.bg/img/entities/391/1460717100_200_piano-bar-Camino-sofia-215-x-130.jpg" },
        //    new Bar() {Id = "cdb2058c-0600-497d-b48d-f89d8cb4aaed", Name = "Motto", Address = "Aksakov 18 str.", PhoneNumber = "029872723", PicUrl = "https://www.bar.bg/img/entities/344/image344_thumb.jpg"},
        //    new Bar() {Id = "6e1ce019-108e-4ded-b308-486831d19e08", Name = "Magnito", },
        //    new Bar() {Id = "d886baac-17e6-49dd-93ec-b5ecadc14e06", Name = "Tobacco Garden Bar", },
        //    new Bar() {Id = "648ba3bd-70ae-4277-aa40-2da5ab120fa9", Name = "The Corner", },
        //    new Bar() {Id = "0086952e-e33e-4daa-a678-d715afb9ce92", Name = "After Five", },
        //    new Bar() {Id = "2600172c-9d3e-4143-850e-aeb80e2a1276", Name = "Ginger", },
        //    new Bar() {Id = "b14aaaf8-5cf8-4c3d-b082-e18afa02f563", Name = "Sinatra", },
        //    new Bar() {Id = "5182e54c-ed6f-487f-b205-75649ef9ea2e", Name = "Cache", },
        //    new Bar() {Id = "091bf67e-532c-498e-9a40-5f625ccee2e2", Name = "Public Bar", }
        //};

        public DbSet<BarComment> BarComments { get; set; }
        public DbSet<BarRating> BarRatings { get; set; }
        public DbSet<CocktailComment> CocktailComments { get; set; }
        public DbSet<CocktailRating> CocktailRatings { get; set; }

        public DbSet<Bar> Bars { get; set; }
        public DbSet<Cocktail> Cocktails { get; set; }
        public DbSet<CocktailBar> CocktailBars { get; set; }
        public DbSet<CocktailIngredient> CocktailIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Rating> Ratings { get; set; }

        public IriOnCocktailServiceDbContext(DbContextOptions<IriOnCocktailServiceDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // User
            builder.Entity<User>()
                .HasKey(user => user.Id);

            builder.Entity<User>()
                .HasMany(user => user.BarComments)
                .WithOne(comment => comment.User);

            builder.Entity<User>()
                .HasMany(user => user.BarRatings)
                .WithOne(rating => rating.User);

            // Bar
            builder.Entity<Bar>()
                .HasKey(bar => bar.Id);

            builder.Entity<Bar>()
                .Property(bar => bar.Name)
                .IsRequired();

            // TODO IsUnique attribute 
            builder.Entity<Bar>()
                .Property(bar => bar.Address)
                .IsRequired();

            builder.Entity<Bar>()
                .HasMany(bar => bar.BarComments)
                .WithOne(comment => comment.Bar)
                .HasForeignKey(comment => comment.BarId);

            //builder.Entity<Bar>()
            //    .HasMany(bar => bar.BarRatings)
            //    .WithOne(rating => rating.Bar)
            //    .HasForeignKey(rating => rating.BarId);

            // Cocktail
            builder.Entity<Cocktail>()
                .HasKey(cocktail => cocktail.Id);

            builder.Entity<Cocktail>()
                .Property(cocktail => cocktail.Name)
                .IsRequired();

            builder.Entity<Cocktail>()
                .HasMany(bar => bar.Comments)
                .WithOne(comment => comment.Cocktail)
                .HasForeignKey(comment => comment.CocktailId);

            builder.Entity<Cocktail>()
                .HasMany(bar => bar.Ratings)
                .WithOne(rating => rating.Cocktail)
                .HasForeignKey(rating => rating.CocktailId);

            // CocktailBar
            builder.Entity<CocktailBar>()
                .HasKey(cocktailBar => new { cocktailBar.CocktailId, cocktailBar.BarId });

            builder.Entity<CocktailBar>()
                .HasOne(cocktailBar => cocktailBar.Cocktail)
                .WithMany(cocktail => cocktail.CocktailBars)
                .HasForeignKey(cocktailBar => cocktailBar.CocktailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CocktailBar>()
                .HasOne(cocktailBar => cocktailBar.Bar)
                .WithMany(bar => bar.CocktailBars)
                .HasForeignKey(cocktailBar => cocktailBar.BarId)
                .OnDelete(DeleteBehavior.Restrict);

            // CocktailIngredient
            builder.Entity<CocktailIngredient>()
                .HasKey(cocktailIngredient => new { cocktailIngredient.CocktailId, cocktailIngredient.IngredientId });

            builder.Entity<CocktailIngredient>()
                .Property(cocktailIngredient => cocktailIngredient.Quantity)
                .IsRequired();

            builder.Entity<CocktailIngredient>()
                .HasOne(cocktailIngredient => cocktailIngredient.Cocktail)
                .WithMany(cocktail => cocktail.CocktailIngredients)
                .HasForeignKey(cocktailIngredient => cocktailIngredient.CocktailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CocktailIngredient>()
                .HasOne(cocktailIngredient => cocktailIngredient.Ingredient)
                .WithMany(ingredient => ingredient.CocktailIngredients)
                .HasForeignKey(cocktailIngredient => cocktailIngredient.IngredientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Ingredient
            builder.Entity<Ingredient>()
                .HasData(ingredientSeader);

            builder.Entity<Ingredient>()
                .HasKey(ingredient => ingredient.Id);

            builder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Name)
                .IsRequired();

            builder.Entity<Ingredient>()
                .Property(ingredient => ingredient.UnitType)
                .IsRequired();

            // Rating
            builder.Entity<Rating>()
                .Property(rating => rating.Rate)
                .HasColumnType("decimal(18,2)");
        }
    }
}
