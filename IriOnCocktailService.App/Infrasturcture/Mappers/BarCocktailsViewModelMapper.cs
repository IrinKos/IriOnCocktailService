using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class BarCocktailsViewModelMapper : IViewModelMapper<AddCocktailDTO, BarCocktailsViewModel>
    {
        public BarCocktailsViewModel MapFromDTO(AddCocktailDTO dto)
        {
            return new BarCocktailsViewModel()
            {
                Id=dto.Id,
                Name=dto.Name,
                PicUrl=dto.PicUrl,
            };
        }
    }
}
