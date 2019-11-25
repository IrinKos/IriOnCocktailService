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
    public class EditCocktailAsync_Should
    {
        [TestMethod]
        public async Task EditCocktailAsyncEditsCorrectly()
        {
            //Arrange
            var options = TestUtilities.GetOptions(nameof(EditCocktailAsyncEditsCorrectly));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            var cocktailDTO = new CocktailDTO()
            {
                Id="1",
                Name = "name2",
                PicUrl = "picture2",
                Motto = "motto2",
            };

            var cocktail = new Cocktail()
            {
                Id="1",
                Name="name",
                PicUrl="picture",
                Motto="motto"
            };
            //Act

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                actContext.Cocktails.Add(cocktail);
                await actContext.SaveChangesAsync();

                var sut = new CocktailService(actContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await sut.EditCocktailAsync(cocktailDTO);
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                Assert.AreEqual(cocktailDTO.Name, cocktail.Name);
                Assert.AreEqual(cocktailDTO.PicUrl, cocktail.PicUrl);
                Assert.AreEqual(cocktailDTO.Motto, cocktail.Motto);
            }
        }
    }
}
