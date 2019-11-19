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
        //private readonly List<Cocktail> cocktailSeader = new List<Cocktail>()
        //{
        //    new Cocktail()
        //    {
        //        Id = "26531c92-59cd-4503-86c9-17ab02d0e4c1",
        //        Name = "Dry Martini",
        //        PicUrl = "https://cdn.liquor.com/wp-content/uploads/2019/07/15140312/Bombay-Sapphire-Martini-Feature.jpg",
        //        CocktailIngredients =
        //            new List<CocktailIngredient>()
        //                {
        //                    new CocktailIngredient()
        //                    { IngredientId = "8a26e862-811d-4053-bb2d-59587bb48188", Quantity = "60" },
        //                    new CocktailIngredient()
        //                    { IngredientId = "6c9dea74-cb47-4d4a-81ec-c21b1aec70ee", Quantity = "25" }
        //                }
        //    }
        //};

        private readonly List<Ingredient> ingredientSeader = new List<Ingredient>()
        {
            new Ingredient() {Id = "0af163c4-6210-4b51-9032-8cadf025083e", IsDeleted = false, UnitType = Unit.Quantity, Name = "Ground black pepper"},
            new Ingredient() {Id = "b46b8769-53d2-4aff-b538-f99948962172", IsDeleted = false, UnitType = Unit.Ml, Name = "Tomato Juice"},
            new Ingredient() {Id = "514afb68-79a8-4deb-bd9c-9d9c61afc1cb", IsDeleted = false, UnitType = Unit.Ml, Name = "Hot sauce"},
            new Ingredient() {Id = "7aab7c85-626f-4509-a357-56050fbe66e4", IsDeleted = false, UnitType = Unit.Ml, Name = "Worcestershire sauce"},
            new Ingredient() {Id = "e045e88a-0151-4394-bd23-62622f3335ff", IsDeleted = false, UnitType = Unit.Ml, Name = "Lemon juice"},
            new Ingredient() {Id = "8a26e862-811d-4053-bb2d-59587bb48188", IsDeleted = false, UnitType = Unit.Ml, Name = "Gin Bombay Sapphire"},
            new Ingredient() {Id = "6c9dea74-cb47-4d4a-81ec-c21b1aec70ee", IsDeleted = false, UnitType = Unit.Ml, Name = "Martini "},
            new Ingredient() {Id = "dcb14d4d-6329-4641-bdd1-b02b7174ddcf", IsDeleted = false, UnitType = Unit.Ml, Name = "Vodka"},
            new Ingredient() {Id = "2a34f05b-192a-46be-986a-3f23afa66a65", IsDeleted = false, UnitType = Unit.Ml, Name = "Tequila" },
            new Ingredient() {Id = "cf9db0c7-b266-4238-9b14-2e0b89cda8ef", IsDeleted = false, UnitType = Unit.Ml, Name = "Gin" },
            new Ingredient() {Id = "9dc9533e-6aa5-4483-8613-e7160a17547d", IsDeleted = false, UnitType = Unit.Ml, Name = "Tonik" },
            new Ingredient() {Id = "f99c65e7-fb0b-4723-a3d5-8ac05a8ba1e4", IsDeleted = false, UnitType = Unit.Ml, Name = "CocaCola" },
            new Ingredient() {Id = "a69c54ff-8e93-4181-8998-b4de42304075", IsDeleted = false, UnitType = Unit.Ml, Name = "Soda" },
            new Ingredient() {Id = "6fe3620d-87be-4773-90c1-d0a072f0c838", IsDeleted = false, UnitType = Unit.Ml, Name = "Wiskey" },
            new Ingredient() {Id = "b96ae8b3-7fad-406c-97d2-bc5e6dcc0d8c", IsDeleted = false, UnitType = Unit.Ml, Name = "Red Bull" },
            new Ingredient() {Id = "07ee6b8c-8986-4886-bbfd-cdca6e52a5df", IsDeleted = false, UnitType = Unit.Ml, Name = "Water" },
            new Ingredient() {Id = "d82e5701-27e5-45a2-955d-01d1071fce02", IsDeleted = false, UnitType = Unit.Ml, Name = "Banana Juice" },
            new Ingredient() {Id = "44ebac14-88ca-404f-87e6-ee0f3d3c180e", IsDeleted = false, UnitType = Unit.Ml, Name = "Orange Juice" },
            new Ingredient() {Id = "3fea7311-64e6-4325-af27-28cb41a5cf2c", IsDeleted = false, UnitType = Unit.Gr, Name = "Salt" },
            new Ingredient() {Id = "6852531d-f7ca-4c05-8b02-019a3ac53737", IsDeleted = false, UnitType = Unit.Gr, Name = "Cinnamon" },
            new Ingredient() {Id = "00b7970b-96e4-49ee-97c0-896871d4bd9f", IsDeleted = false, UnitType = Unit.Quantity, Name = "Ice" },
            new Ingredient() {Id = "6e3634b2-518f-40e2-ac20-1bf56297364a", IsDeleted = false, UnitType = Unit.Quantity, Name = "Olive" }
        };

        private List<Bar> barSeader = new List<Bar>()
        {
            new Bar() {Id = "56d9e733-b150-45c4-8b87-f5a5e31bc23b", Name = "Camino Piano Bar", Address = "Neofit Rilski 70 str.", PhoneNumber = "0899 121 219", PicUrl = "https://www.bar.bg/img/entities/391/1460717100_200_piano-bar-Camino-sofia-215-x-130.jpg" },
            new Bar() {Id = "cdb2058c-0600-497d-b48d-f89d8cb4aaed", Name = "Motto", Address = "Aksakov 18 str.", PhoneNumber = "02 987 27 23", PicUrl = "https://www.bar.bg/img/entities/344/image344_thumb.jpg"},
            new Bar() {Id = "6e1ce019-108e-4ded-b308-486831d19e08", Name = "Magnito", Address = "Lege 8 str.", PhoneNumber = "0888 144 777",PicUrl = "https://www.bar.bg/img/entities/334/1505111472_200_magnito-sofia-215-x-130.png" },
            new Bar() {Id = "d886baac-17e6-49dd-93ec-b5ecadc14e06", Name = "Tobacco Garden Bar", Address = "Moskovska 6A str.", PhoneNumber = "0884 600 044", PicUrl = "https://www.bar.bg/img/entities/399/1465626692_200_Tobacco-garden-bar-sofia-215-x-130.png"},
            new Bar() {Id = "648ba3bd-70ae-4277-aa40-2da5ab120fa9", Name = "The Corner", Address = "Nikola Vaptsarov 35 bul", PhoneNumber = "0884 555 444", PicUrl = "https://www.bar.bg/img/entities/301/1509363711_200_LOGO_The-Corner-Sofia-2017---215-x-130.jpg"},
            new Bar() {Id = "0086952e-e33e-4daa-a678-d715afb9ce92", Name = "After Five", Address = "Malko Tarnovo 1 str.", PhoneNumber = "0889 044 124", PicUrl = "https://www.bar.bg/img/entities/514/1542282680_200_1-after%20five%20drink%20bar%20sofia%20215-x-130.jpg"},
            new Bar() {Id = "2600172c-9d3e-4143-850e-aeb80e2a1276", Name = "Ginger", Address = "Bitolya 2 str.", PhoneNumber = "087 733 7337", PicUrl = "https://www.bar.bg/img/entities/309/1542618320_200_1-ginger%20sofia%20215-x-130%20logo.png"},
            new Bar() {Id = "b14aaaf8-5cf8-4c3d-b082-e18afa02f563", Name = "Sinatra", Address = "Vitosha 16 str.", PhoneNumber = "087 676 7647", PicUrl = "https://www.bar.bg/img/entities/445/1495540391_200_Social-cafe-sofia-logo-215-x-130-jpeg.jpg"},
            new Bar() {Id = "5182e54c-ed6f-487f-b205-75649ef9ea2e", Name = "Cache", Address = "Arsenalski 2 bul.", PhoneNumber = "089 446 4169", PicUrl = "https://www.bar.bg/img/entities/392/1460818909_200_cache---215-x-130.jpg"},
            new Bar() {Id = "091bf67e-532c-498e-9a40-5f625ccee2e2", Name = "Public Bar", Address = "Angel Kanchev 1 str.", PhoneNumber = "088 433 3781", PicUrl = "https://www.bar.bg/img/entities/443/1495046748_200_public-bar-sofia--215-x-130.png"}
        };

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
                .HasData(barSeader);

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

            builder.Entity<BarRating>()
                .HasKey(br => new { br.UserId, br.BarId });

            builder.Entity<CocktailRating>()
                .HasKey(br => new { br.UserId, br.CocktailId });
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

            // BarRating
            builder.Entity<BarRating>()
                .Property(br => br.Rate)
                .HasColumnType("decimal(18,2)");

            // CocktailRating
            builder.Entity<CocktailRating>()
                .Property(cr => cr.Rate)
                .HasColumnType("decimal(18,2)");
        }
    }
}
