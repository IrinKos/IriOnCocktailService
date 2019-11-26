using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class DeleteCocktailViewModelMapper : IViewModelMapper<CocktailDTO, DeleteCocktailViewModel>
    {
        public DeleteCocktailViewModel MapFromDTO(CocktailDTO dto)
        {
            return new DeleteCocktailViewModel()
            {
                Name = dto.Name,
                Id = dto.Id,
                PicUrl = dto.PicUrl,
            };
        }
    }
}
