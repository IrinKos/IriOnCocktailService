using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceTests.IngredientServiceTests
{
    [TestClass]
    public class GetAllIngredients_Should
    {
        [TestMethod]
        public async Task GetAllIngredientsCorrectly()
        {
            var options = TestUtilities.GetOptions(nameof(GetAllIngredientsCorrectly));

            var mapToDTOMock = new Mock<IDTOServiceMapper<Ingredient, IngredientDTO>>();
            var mapToEntityMock = new Mock<IDTOServiceMapper<IngredientDTO, Ingredient>>();

            var ingredientDTOMock = new Mock<IngredientDTO>();
            var ingredient = new Ingredient()
            {
                Name = "Chubaka",
                Id = "1",
            };
            var ingredientDTO = new IngredientDTO()
            {
                Name = "Chubaka",
                Id = "1",
            };

            mapToDTOMock.Setup(m => m.MapFrom(It.IsAny<Ingredient>())).Returns(ingredientDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Ingredients.AddAsync(ingredient);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new IngredientService(assertContext, mapToDTOMock.Object, mapToEntityMock.Object);

                var result = await sut.GetAllIngredients();

                Assert.AreEqual(1, result.Count);
            }
        }
        [TestMethod]
        public async Task GetAllIngredientsThrowsWhenNoIngredientsFound()
        {
            var options = TestUtilities.GetOptions(nameof(GetAllIngredientsThrowsWhenNoIngredientsFound));

            var mapToDTOMock = new Mock<IDTOServiceMapper<Ingredient, IngredientDTO>>();
            var mapToEntityMock = new Mock<IDTOServiceMapper<IngredientDTO, Ingredient>>();

            mapToDTOMock.Setup(m => m.MapFrom(It.IsAny<Ingredient>())).Returns(It.IsAny<IngredientDTO>());

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new IngredientService(assertContext, mapToDTOMock.Object, mapToEntityMock.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetAllIngredients());
            }
        }
        [TestMethod]
        public async Task GetAllIngredientsThrowsCorrectMsgWhenNoIngredientsFound()
        {
            var options = TestUtilities.GetOptions(nameof(GetAllIngredientsThrowsCorrectMsgWhenNoIngredientsFound));

            var mapToDTOMock = new Mock<IDTOServiceMapper<Ingredient, IngredientDTO>>();
            var mapToEntityMock = new Mock<IDTOServiceMapper<IngredientDTO, Ingredient>>();

            mapToDTOMock.Setup(m => m.MapFrom(It.IsAny<Ingredient>())).Returns(It.IsAny<IngredientDTO>());

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new IngredientService(assertContext, mapToDTOMock.Object, mapToEntityMock.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetAllIngredients());
            }
        }
    }
}
