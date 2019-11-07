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
                .Property(cocktailIngredient => cocktailIngredient.UnitType)
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
                .HasKey(ingredient => ingredient.Id);

            builder.Entity<Ingredient>()
                .Property(ingredient => ingredient.Name)
                .IsRequired();

            // Rating
            builder.Entity<Rating>()
                .Property(rating => rating.Rate)
                .HasColumnType("decimal(18,2)");
        }
    }
}
