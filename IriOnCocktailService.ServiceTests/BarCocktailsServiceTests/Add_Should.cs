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
    public class Add_Should
    {
        [TestMethod]
        public async Task AddsCorrectly()
        {
            var options = TestUtilities.GetOptions(nameof(AddsCorrectly));


            var bar = new Bar()
            {
                Id = "1",
                Name = "Bar",
            };
            var cocktail = new Cocktail()
            {
                Id = "1",
                Name = "Cocktail",
            };
            var cocktail2 = new Cocktail()
            {
                Id = "2",
                Name = "Cocktail2",
            };

            var cocktailIds = new List<string>();
            cocktailIds.Add(cocktail.Id);
            cocktailIds.Add(cocktail2.Id);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.Cocktails.AddAsync(cocktail2);
                await actContext.Bars.AddAsync(bar);
                await actContext.SaveChangesAsync();

                var sut = new BarCocktailsService(actContext);

                await sut.Add(cocktailIds, bar.Id);
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                Assert.AreEqual(2, assertContext.CocktailBars.Where(cb=>cb.BarId==bar.Id).Count());
            }
        }
    }
}
