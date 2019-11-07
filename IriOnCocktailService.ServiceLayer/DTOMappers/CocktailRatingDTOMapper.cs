using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    class CocktailRatingMapper : IDTOServiceMapper<RatingDTO, CocktailRating>
    {
        public CocktailRating MapFrom(RatingDTO cocktailRatingDTO)
        {
            return new CocktailRating()
            {
                CocktailId = cocktailRatingDTO.BarId,
                Rate = cocktailRatingDTO.Rate,
                UserId = cocktailRatingDTO.UserId,
            };
        }
    }
}
