using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class BarRatingDTOMapper : IDTOServiceMapper<RatingDTO, BarRating>
    {
        public BarRating MapFrom(RatingDTO barRatingDTO)
        {
            return new BarRating()
            {
                BarId=barRatingDTO.BarId,
                Rate = barRatingDTO.Rate,
                UserId=barRatingDTO.UserId,
            };
        }
    }
}
