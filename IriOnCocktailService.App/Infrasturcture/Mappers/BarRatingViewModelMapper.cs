using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarRatingViewModelMapper : IDTOMapper<BarRatingViewModel, BarRatingDTO>
    {
        public BarRatingDTO MapFromViewModel(BarRatingViewModel viewModel)
        {
            return new BarRatingDTO()
            {
                BarId = viewModel.Id,
                UserId = viewModel.UserId,
                Rate = viewModel.Rate,
            };
        }
    }
}
