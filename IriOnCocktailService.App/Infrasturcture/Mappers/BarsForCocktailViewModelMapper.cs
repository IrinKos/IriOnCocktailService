using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarsForCocktailViewModelMapper : IViewModelMapper<BarDTO, BarsForCocktailViewModel>
    {
        public BarsForCocktailViewModel MapFromDTO(BarDTO dto)
        {
            return new BarsForCocktailViewModel()
            {
                Id=dto.BarId,
                Name=dto.BarName,
                PicUrl=dto.BarPicUrl
            };
        }
    }
}
