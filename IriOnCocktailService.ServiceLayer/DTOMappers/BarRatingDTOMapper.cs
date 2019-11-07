using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class BarRatingDTOMapper : IDTOServiceMapper<BarRating, BarRatingDTO>,
                                      IDTOServiceMapper<BarRatingDTO, BarRating>
    {
        public BarRating MapFrom(BarRatingDTO barRatingDTO)
        {
            return new BarRating()
            {
                BarId=barRatingDTO.BarId,
                Rate = barRatingDTO.Rate,
                UserId=barRatingDTO.UserId,
            };
        }
        public BarRatingDTO MapFrom(BarRating entity)
        {
            throw new NotImplementedException();
        }

    }
}
