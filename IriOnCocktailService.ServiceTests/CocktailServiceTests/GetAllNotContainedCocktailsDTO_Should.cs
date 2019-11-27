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
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceTests.CocktailServiceTests
{
    [TestClass]
    public class GetAllNotContainedCocktailsDTO_Should
    {
        [TestMethod]
        public async Task GetAllNotContainedCocktailsDTOCorrectly()
        {
            var options = TestUtilities.GetOptions(nameof(GetAllNotContainedCocktailsDTOCorrectly));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            var bar = new Bar()
            {
                Id = "1",
                Name = "name",
                Address = "address",
                Motto = "motto",
                PicUrl = "picture",
            };
            var cocktail = new Cocktail()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };
            var cocktail2 = new Cocktail()
            {
                Name = "Name",
                Id = "2",
                Motto = "Motto",
                PicUrl = "Pic",
            };
            var cocktailBar = new CocktailBar
            {
                CocktailId = "1",
                BarId = "1",
            };
            //Act
            //cocktailMapperMock.Setup(m => m.MapFrom(It.IsAny<Cocktail>())).Returns(cocktailDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Bars.AddAsync(bar);
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.Cocktails.AddAsync(cocktail2);
                await actContext.SaveChangesAsync();
                await actContext.CocktailBars.AddAsync(cocktailBar);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                var result = await sut.GetAllNotContainedCocktailsDTO("1");
                Assert.AreEqual(1, result.Count);
            }
        }
    }
}
