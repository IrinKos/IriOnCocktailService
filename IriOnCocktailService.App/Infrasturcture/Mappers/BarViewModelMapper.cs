using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.App.Models;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarViewModelMapper : IViewModelMapper<BarDTO, BarViewModel>
                                      
    {
        public BarViewModel MapFromDTO(BarDTO dto)
        {
            return new BarViewModel
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

        //public BarDTO MapFromViewModel(BarViewModel viewModel)
        //{
        //    return new BarDTO
        //    {
        //        BarId = viewModel.Id,
        //        BarName = viewModel.Name,
        //        BarAddress = viewModel.Address,
        //        BarPicUrl = viewModel.PictureURL,
        //        BarPhoneNumber = viewModel.PhoneNumber,
        //        Motto = viewModel.Motto,
        //        BarRatings = viewModel..Any(br => br.BarId == viewModel.BarId) ? viewModel.BarRatings.Where(br => br.BarId == viewModel.BarId).Average(g => g.Rate) : 0,
        //    };
        //}
    }
}
