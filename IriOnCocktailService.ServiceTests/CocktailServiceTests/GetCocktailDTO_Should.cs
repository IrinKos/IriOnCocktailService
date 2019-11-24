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
    public class GetCocktailDTO_Should
    {
        [TestMethod]
        public async Task GetCocktailDTOReturnCorrectDTO()
        {
            var options = TestUtilities.GetOptions(nameof(GetCocktailDTOReturnCorrectDTO));

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
                Name ="Name",
                Id = "1",
                Motto="Motto",
                PicUrl="Pic",
            };

            var cocktailDTO = new CocktailDTO()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
            };

            var cocktailDTOMock = new Mock<CocktailDTO>();
            var cocktailMock = new Mock<Cocktail>();
            //Act
            cocktailMapperMock.Setup(m => m.MapFrom(It.IsAny<Cocktail>())).Returns(cocktailDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                var result = await sut.GetCocktailDTO(cocktail.Id);
                Assert.AreEqual(cocktailDTO.Id, result.Id);
                Assert.AreEqual(cocktailDTO.Name, result.Name);
                Assert.AreEqual(cocktailDTO.Motto, result.Motto);
                Assert.AreEqual(cocktailDTO.PicUrl, result.PicUrl);
            }
        }
        [TestMethod]
        public async Task GetCocktailDTO_ThrowsWhenNotAvailable()
        {
            var options = TestUtilities.GetOptions(nameof(GetCocktailDTO_ThrowsWhenNotAvailable));

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
                NotAvailable=true,
            };

            var cocktailDTO = new CocktailDTO()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
                NotAvailable = true,
            };

            var cocktailDTOMock = new Mock<CocktailDTO>();
            var cocktailMock = new Mock<Cocktail>();
            //Act
            cocktailMapperMock.Setup(m => m.MapFrom(It.IsAny<Cocktail>())).Returns(cocktailDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetCocktailDTO("1"));
            }
        }
        [TestMethod]
        public async Task GetCocktailDTO_ThrowsCorrectMsgWhenNotAvailable()
        {
            var options = TestUtilities.GetOptions(nameof(GetCocktailDTO_ThrowsCorrectMsgWhenNotAvailable));

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
                NotAvailable = true,
            };

            var cocktailDTO = new CocktailDTO()
            {
                Name = "Name",
                Id = "1",
                Motto = "Motto",
                PicUrl = "Pic",
                NotAvailable = true,
            };

            var cocktailDTOMock = new Mock<CocktailDTO>();
            var cocktailMock = new Mock<Cocktail>();
            //Act
            cocktailMapperMock.Setup(m => m.MapFrom(It.IsAny<Cocktail>())).Returns(cocktailDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                await actContext.Cocktails.AddAsync(cocktail);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetCocktailDTO("1"),GlobalConstants.UnavailableCocktail);
            }
        }
        [TestMethod]
        public async Task GetCocktailDTO_ThrowsWhenNull()
        {
            var options = TestUtilities.GetOptions(nameof(GetCocktailDTO_ThrowsWhenNull));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(()=> sut.GetCocktailDTO("1"));
            }
        }
        [TestMethod]
        public async Task GetCocktailDTO_ThrowsCorrectMsgWhenNull()
        {
            var options = TestUtilities.GetOptions(nameof(GetCocktailDTO_ThrowsCorrectMsgWhenNull));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(assertContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await Assert.ThrowsExceptionAsync<ArgumentException>(()=> sut.GetCocktailDTO("1"),GlobalConstants.UnavailableCocktail);
            }
        }
    }
}
