using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class DisplayBarsViewModelMapper : IViewModelMapper<BarDTO, DisplayBarsViewModel>
    {
        public DisplayBarsViewModel MapFromDTO(BarDTO dto)
        {
            var viewModel =  new DisplayBarsViewModel
            {
                Name = dto.BarName,
                Address=dto.BarAddress,
                PictureURL=dto.BarPicUrl
            };
            if (dto.BarRatings.Where(br => br.BarId == dto.BarId).Any())
            {
                viewModel.Rating = dto.BarRatings.Where(br => br.BarId == dto.BarId).Average(g => g.Rate);
            }
            else
                viewModel.Rating = 0;

            return viewModel;
        }
    }
}
