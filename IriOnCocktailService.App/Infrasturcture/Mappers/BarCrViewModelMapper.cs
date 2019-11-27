using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarCrViewModelMapper : IViewModelMapper<BarDTO, BarCrViewModel>
    {
        public BarCrViewModel MapFromDTO(BarDTO dto)
        {
            return new BarCrViewModel
            {
                Id = dto.BarId,
                Name = dto.BarName,
                Address = dto.BarAddress,
                PictureURL = dto.BarPicUrl,
                PhoneNumber = dto.BarPhoneNumber,
                Motto = dto.Motto,
                Rating = dto.BarRatings.Any(br => br.BarId == dto.BarId) ? dto.BarRatings.Where(br => br.BarId == dto.BarId).Average(g => g.Rate) : 0,
            };
        }
    }
}
