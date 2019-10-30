using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UpdateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<IriOnCocktailServiceDbContext>();
                context.Database.EnsureCreated();

                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();


                Task.Run(async () =>
                {
                    var adminName = "CocktailMagician";

                    var exists = await roleManager.RoleExistsAsync(adminName);

                    if (!exists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = adminName
                        });
                    }

                    var librarianName = "BarCrawler";

                    var librarianExists = await roleManager.RoleExistsAsync(librarianName);

                    if (!librarianExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole
                        {
                            Name = librarianName
                        });
                    }

                    var adminUser = await userManager.FindByNameAsync(adminName);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            UserName = "admin",
                            Email = "admin@admin.com",
                            //Role = 
                            
                        };

                        await userManager.CreateAsync(adminUser, "admin12");
                        await userManager.AddToRoleAsync(adminUser, adminName);
                    }

                })
                .GetAwaiter()
                .GetResult();
            }

        }
    }
}
