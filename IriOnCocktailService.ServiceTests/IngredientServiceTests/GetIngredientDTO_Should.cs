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
    public class GetIngredientDTO_Should
    {
        [TestMethod]
        public async Task GetIngredientReturnsCorrectValue()
        {
            var options = TestUtilities.GetOptions(nameof(GetIngredientReturnsCorrectValue));

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

                var dto = await sut.GetIngredientDTO("1");

                Assert.AreEqual("1", dto.Id);
                Assert.AreEqual("Chubaka", dto.Name);
            }
        }
        [TestMethod]
        public async Task GetIngredientReturnsCorrectInstance()
        {
            var options = TestUtilities.GetOptions(nameof(GetIngredientReturnsCorrectInstance));

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

                var dto = await sut.GetIngredientDTO("1");

                Assert.IsInstanceOfType(dto, typeof(IngredientDTO));
            }
        }
        [TestMethod]
        public async Task GetIngredientReturnsNotNull()
        {
            var options = TestUtilities.GetOptions(nameof(GetIngredientReturnsNotNull));

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

                var dto = await sut.GetIngredientDTO("1");

                Assert.IsNotNull(dto);
            }
        }
        [TestMethod]
        public async Task GetIngredientThrowsWhenNull()
        {
            var options = TestUtilities.GetOptions(nameof(GetIngredientThrowsWhenNull));

            var mapToDTOMock = new Mock<IDTOServiceMapper<Ingredient, IngredientDTO>>();
            var mapToEntityMock = new Mock<IDTOServiceMapper<IngredientDTO, Ingredient>>();

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new IngredientService(assertContext, mapToDTOMock.Object, mapToEntityMock.Object);

                await Assert.ThrowsExceptionAsync< ArgumentException>(()=> sut.GetIngredientDTO("1"));
            }
        }
        [TestMethod]
        public async Task GetIngredientThrowsCorrectMsg()
        {
            var options = TestUtilities.GetOptions(nameof(GetIngredientThrowsWhenNull));

            var mapToDTOMock = new Mock<IDTOServiceMapper<Ingredient, IngredientDTO>>();
            var mapToEntityMock = new Mock<IDTOServiceMapper<IngredientDTO, Ingredient>>();

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new IngredientService(assertContext, mapToDTOMock.Object, mapToEntityMock.Object);

                await Assert.ThrowsExceptionAsync< ArgumentException>(()=> sut.GetIngredientDTO("1"),GlobalConstants.UnavailbleIngredient);
            }
        }
    }
}