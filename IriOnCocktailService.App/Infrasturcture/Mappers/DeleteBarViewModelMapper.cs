using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class DeleteBarViewModelMapper : IViewModelMapper<BarDTO, DeleteBarViewModel>
    {
        public DeleteBarViewModel MapFrom(BarDTO dto)
        {
            return new DeleteBarViewModel()
            {
                Id=dto.BarId,
            };
        }
    }
}
