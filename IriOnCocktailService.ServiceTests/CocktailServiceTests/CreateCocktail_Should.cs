using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class CreateCocktail_Should
    {
        [TestMethod]
        public async Task CreateCocktailCorrectly()
        {
            //Arrange
            var options = TestUtilities.GetOptions(nameof(CreateCocktailCorrectly));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            var cocktailDTOMock = new Mock<CocktailDTO>();
            var cocktailIngredientDTOMock = new Mock<List<CocktailIngredientDTO>>();
            var cocktailMock = new Mock<Cocktail>();
            cocktailDTOMock.Object.Ingredients = cocktailIngredientDTOMock.Object;
            //Act
            cocktailMapperToDTOMock.Setup(m => m.MapFrom(It.IsAny<CocktailDTO>())).Returns(cocktailMock.Object);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(actContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await sut.CreateCocktail(cocktailDTOMock.Object);
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                Assert.AreEqual(1, assertContext.Cocktails.Count());
            }
        }
        [TestMethod]
        public async Task CreateCocktail_ThrowWhenDTOIsNull()
        {
            //Arrange
            var options = TestUtilities.GetOptions(nameof(CreateCocktail_ThrowWhenDTOIsNull));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(actContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateCocktail(null));
            }
        }
        [TestMethod]
        public async Task CreateCocktail_ThrowCorrectMsgWhenDTOIsNull()
        {
            //Arrange
            var options = TestUtilities.GetOptions(nameof(CreateCocktail_ThrowCorrectMsgWhenDTOIsNull));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(actContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => sut.CreateCocktail(null), "The given parameter is null");
            }
        }
    }
}
