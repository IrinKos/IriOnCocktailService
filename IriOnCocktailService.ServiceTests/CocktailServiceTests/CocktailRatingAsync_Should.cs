﻿using IriOnCocktailService.Data;
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
    public class CocktailRatingAsync_Should
    {
        [TestMethod]
        public async Task CocktailRatingAsyncCreatedCorrectly()
        {
            //Arrange
            var options = TestUtilities.GetOptions(nameof(CocktailRatingAsyncCreatedCorrectly));

            var ingredientServiceMock = new Mock<ICocktailIngredientService>();
            var cocktailMapperToDTOMock = new Mock<IDTOServiceMapper<CocktailDTO, Cocktail>>();
            var cocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, CocktailDTO>>();
            var commentMapperToDTOMock = new Mock<IDTOServiceMapper<CommentDTO, CocktailComment>>();
            var commentMapperMock = new Mock<IDTOServiceMapper<CocktailComment, CommentDTO>>();
            var addCocktailMapperMock = new Mock<IDTOServiceMapper<Cocktail, AddCocktailDTO>>();
            var cocktailRatingToDTOMock = new Mock<IDTOServiceMapper<RatingDTO, CocktailRating>>();

            //Act
            var cocktailRatingDTO = new CocktailRating();
            var RatingDTOMock = new Mock<RatingDTO>();
            cocktailRatingToDTOMock.Setup(m => m.MapFrom(It.IsAny<RatingDTO>())).Returns(cocktailRatingDTO);

            using (var actContext = new IriOnCocktailServiceDbContext(options))
            {
                var sut = new CocktailService(actContext, ingredientServiceMock.Object, cocktailMapperMock.Object, cocktailMapperToDTOMock.Object, commentMapperToDTOMock.Object, commentMapperMock.Object, addCocktailMapperMock.Object, cocktailRatingToDTOMock.Object);

                await sut.CocktailRatingAsync(RatingDTOMock.Object);
            }

            using (var assertContext = new IriOnCocktailServiceDbContext(options))
            {
                Assert.AreEqual(1, assertContext.CocktailRatings.Count());
            }
        }
    }
}
