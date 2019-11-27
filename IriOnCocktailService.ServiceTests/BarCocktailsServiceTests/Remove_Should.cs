using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceTests.BarCocktailsServiceTests
{
    [TestClass]
    public class Remove_Should
    {
        [TestMethod]
        public async Task RemoveCorrectly()
        {
            var options = TestUtilities.GetOptions(nameof(RemoveCorrectly));

            var bar = new Bar()
            {
                Id = "8",
                Name = "Bar",
            };
            var cocktail = new Cocktail()
            {
                Id = "9",
                Name = "Cocktail",
            };
            var barcocktail = new CocktailBar()
            {
                BarId = "8",
                CocktailId = "9"
            };
            var cocktailIds = new List<string>();
            cocktailIds.Add(cocktail.Id);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.Bars.AddAsync(bar);
                await actContext.CocktailBars.AddAsync(barcocktail);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new BarCocktailsService(assertContext);

                await sut.Remove(cocktailIds, bar.Id);
                Assert.AreEqual(0, assertContext.CocktailBars.Where(cb => cb.BarId == bar.Id).Count());
            }
        }
    }
}
