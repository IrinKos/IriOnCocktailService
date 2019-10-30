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
                .HasMany(user => user.Comments)
                .WithOne(comment => comment.User);

            builder.Entity<User>()
                .HasMany(user => user.Ratings)
                .WithOne(rating => rating.User);

            // Bar
            builder.Entity<Bar>()
                .HasKey(bar => bar.Id);

            builder.Entity<Bar>()
                .Property(b => b.Name)
                .IsRequired();

            builder.Entity<Bar>()
                .Property(b => b.Address)
                .IsRequired();

            builder.Entity<Bar>()
                .HasMany(bar => bar.Comments)
                .WithOne(comment => comment.Bar)
                .HasForeignKey(comment => comment.BarId);

            builder.Entity<Bar>()
                .HasMany(bar => bar.Ratings)
                .WithOne(rating => rating.Bar)
                .HasForeignKey(rating => rating.BarId);

            //builder.Entity<Bar>()
            //    .HasMany(bar => bar.Cocktails)
                
        }
    }
}
