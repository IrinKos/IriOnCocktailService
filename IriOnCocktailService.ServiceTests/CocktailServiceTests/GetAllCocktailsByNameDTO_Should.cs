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
    public class GetAllCocktailsByNameDTO_Should
    {
        [TestMethod]
        public async Task GetAllCocktailsByNameDTOReturnsCorrectCocktails()
        {
            var options = TestUtilities.GetOptions(nameof(GetAllCocktailsByNameDTOReturnsCorrectCocktails));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            var ingrMapper = new Mock<IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO>>();
            ingrMapper.Setup(x => x.MapFrom(It.IsAny<CocktailIngredient>())).Returns(It.IsAny<CocktailIngredientDTO>());
            var cocktail = new Cocktail()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };
            var cocktail2 = new Cocktail()
            {
                Name = "Name2",
                Id = "12",
                Motto = "Motto2",
                PicUrl = "Pic2",
            };

            var cocktailDTO = new CocktailDTO()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };

            //Act
            cocktailMapperMock.Setup(m => m.MapFrom(It.IsAny<Cocktail>())).Returns(cocktailDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.Cocktails.AddAsync(cocktail2);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);


                var result = await sut.GetAllCocktailsByNameDTO("name");
                Assert.AreEqual(2, result.Count);
            }
        }
        [TestMethod]
        public async Task GetAllCocktailsByNameDTO_ThrowsWhenNoResultsFound()
        {
            var options = TestUtilities.GetOptions(nameof(GetAllCocktailsByNameDTO_ThrowsWhenNoResultsFound));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            var ingrMapper = new Mock<IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO>>();
            ingrMapper.Setup(x => x.MapFrom(It.IsAny<CocktailIngredient>())).Returns(It.IsAny<CocktailIngredientDTO>());
            var cocktail = new Cocktail()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };
            var cocktail2 = new Cocktail()
            {
                Name = "Name2",
                Id = "12",
                Motto = "Motto2",
                PicUrl = "Pic2",
            };

            var cocktailDTO = new CocktailDTO()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };

            //Act
            cocktailMapperMock.Setup(m => m.MapFrom(It.IsAny<Cocktail>())).Returns(cocktailDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.Cocktails.AddAsync(cocktail2);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);


                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetAllCocktailsByNameDTO("z"));
            }
        }
        [TestMethod]
        public async Task GetAllCocktailsByNameDTO_ThrowsCorrectMsgWhenNoResultsFound()
        {
            var options = TestUtilities.GetOptions(nameof(GetAllCocktailsByNameDTO_ThrowsCorrectMsgWhenNoResultsFound));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            var ingrMapper = new Mock<IDTOServiceMapper<CocktailIngredient, CocktailIngredientDTO>>();
            ingrMapper.Setup(x => x.MapFrom(It.IsAny<CocktailIngredient>())).Returns(It.IsAny<CocktailIngredientDTO>());
            var cocktail = new Cocktail()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };
            var cocktail2 = new Cocktail()
            {
                Name = "Name2",
                Id = "12",
                Motto = "Motto2",
                PicUrl = "Pic2",
            };

            var cocktailDTO = new CocktailDTO()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };

            //Act
            cocktailMapperMock.Setup(m => m.MapFrom(It.IsAny<Cocktail>())).Returns(cocktailDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.Cocktails.AddAsync(cocktail2);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);


                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetAllCocktailsByNameDTO("z"));
            }
        }
    }
}
