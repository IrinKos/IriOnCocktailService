using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CreateBarViewModelMapper : IViewModelMapper<BarDTO, CreateBarViewModel>,
                                            IDTOMapper<CreateBarViewModel,BarDTO>
    {
        public CreateBarViewModel MapFromDTO(BarDTO dto)
        {
            return new CreateBarViewModel()
            {
                BarName = dto.BarName,
                BarAddress=dto.BarAddress,
                BarId=dto.BarId,
                BarPhoneNumber=dto.BarPhoneNumber,
                BarPicUrl=dto.BarPicUrl,
                BarNotAvailable=dto.BarNotAvailable
            };
        }

        public BarDTO MapFromViewModel(CreateBarViewModel viewModel)
        {
            return new BarDTO()
            {
                BarName = viewModel.BarName,
                BarAddress = viewModel.BarAddress,
                BarId = viewModel.BarId,
                BarPhoneNumber = viewModel.BarPhoneNumber,
                BarPicUrl = viewModel.BarPicUrl,
                BarNotAvailable = viewModel.BarNotAvailable
            };
        }
    }
}
