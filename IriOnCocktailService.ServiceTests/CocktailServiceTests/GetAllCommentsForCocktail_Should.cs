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
    public class GetAllCommentsForCocktail_Should
    {
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public async Task GetAllCommentsForCocktailCorrectly()
        {
            var options = TestUtilities.GetOptions(nameof(GetAllCommentsForCocktailCorrectly));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();
         
            var cocktail = new Cocktail()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };
            var cocktailComment = new CocktailComment
            {
                CocktailId = "1",
                Description = "description",
                CreatedOn = DateTime.Now,
            };
            var cocktailComment2 = new CocktailComment
            {
                CocktailId = "1",
                Description = "description",
                CreatedOn = DateTime.Now,
            };
            //Act
            //cocktailMapperMock.Setup(m => m.MapFrom(It.IsAny<Cocktail>())).Returns(cocktailDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.SaveChangesAsync();
                await actContext.CocktailComments.AddAsync(cocktailComment);
                await actContext.CocktailComments.AddAsync(cocktailComment2);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                var result = await sut.GetAllCommentsForCocktail("1");
                Assert.AreEqual(2, result.Count);
            }
        }
    }
}
