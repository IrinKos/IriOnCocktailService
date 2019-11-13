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
            return new DisplayBarsViewModel
            {
                Id = dto.BarId,
                Name = dto.BarName,
                Address = dto.BarAddress,
                PictureURL = dto.BarPicUrl,
                PhoneNumber = dto.BarPhoneNumber,
                Rating = dto.BarRatings.Any(br => br.BarId == dto.BarId) ? dto.BarRatings.Where(br => br.BarId == dto.BarId).Average(g => g.Rate) : 0,
            };
        }
    }
}
