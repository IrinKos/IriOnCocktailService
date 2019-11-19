using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class BarCocktailsService : IBarCocktailsService
    {
        private readonly IriOnCocktailServiceDbContext context;

        public BarCocktailsService(IriOnCocktailServiceDbContext context)
        {
            this.context = context;
        }

        public async Task Add(List<string> cocktails, string barId)
        {
            if (cocktails != null)
            {
                foreach (var item in cocktails)
                {
                    var cocktailBar = new CocktailBar
                    {
                        BarId = barId,
                        CocktailId = item,
                    };
                    await this.context.CocktailBars.AddAsync(cocktailBar);
                }
                await this.context.SaveChangesAsync();
            }
        }
        public async Task Remove(List<string> cocktails, string barId)
        {
            if (cocktails != null)
            {
                foreach (var item in cocktails)
                {
                    var cocktailBar = new CocktailBar
                    {
                        BarId = barId,
                        CocktailId = item,
                    };
                    this.context.CocktailBars.Remove(cocktailBar);
                }
                await this.context.SaveChangesAsync();
            }
        }
    }
}
