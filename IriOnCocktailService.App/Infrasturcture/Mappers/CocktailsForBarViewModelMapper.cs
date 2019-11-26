using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CocktailsForBarViewModelMapper : IViewModelMapper<AddCocktailDTO, CocktailsForBarViewModel>
    {
        public CocktailsForBarViewModel MapFromDTO(AddCocktailDTO dto)
        {
            return new CocktailsForBarViewModel()
            {
                Id = dto.Id,
                Name = dto.Name,
                PicUrl = dto.PicUrl
            };
        }
    }
}
