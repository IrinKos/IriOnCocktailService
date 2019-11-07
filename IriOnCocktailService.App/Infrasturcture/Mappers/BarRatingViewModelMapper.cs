using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarRatingViewModelMapper : IDTOMapper<RatingViewModel, RatingDTO>
    {
        public RatingDTO MapFromViewModel(RatingViewModel viewModel)
        {
            return new RatingDTO()
            {
                BarId = viewModel.Id,
                UserId = viewModel.UserId,
                Rate = viewModel.Rate,
            };
        }
    }
}
