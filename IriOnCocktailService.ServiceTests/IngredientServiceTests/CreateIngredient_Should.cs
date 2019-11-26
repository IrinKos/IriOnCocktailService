using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceTests.IngredientServiceTests
{
    [TestClass]
    public class CreateIngredient_Should
    {
        [TestMethod]
        public async Task CreateIngredientCorrectly()
        {
            var options = TestUtilities.GetOptions(nameof(CreateIngredientCorrectly));

            var mapToDTOMock = new Mock<IDTOServiceMapper<Ingredient, IngredientDTO>>();
            var mapToEntityMock = new Mock<IDTOServiceMapper<IngredientDTO, Ingredient>>();

            var ingredientDTOMock = new Mock<IngredientDTO>();
            var ingredient = new Ingredient()
            {
                Name = "Chubaka",
                Id = "1",
            };

            mapToEntityMock.Setup(m => m.MapFrom(ingredientDTOMock.Object)).Returns(ingredient);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new IngredientService(actContext, mapToDTOMock.Object, mapToEntityMock.Object);

                await sut.CreateIngredient(ingredientDTOMock.Object);
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                Assert.AreEqual(1, assertContext.Ingredients.Count());
            }
        }
    }
}
