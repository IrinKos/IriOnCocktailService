using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class DisplayCocktailViewModelMapper : IViewModelMapper<CocktailDTO, DisplayCocktailViewModel>,                                                                IViewModelMapper<AddCocktailDTO, DisplayCocktailViewModel>
                                                  
    {
        public DisplayCocktailViewModel MapFromDTO(CocktailDTO dto)
        {
            return new DisplayCocktailViewModel
            {
                Id=dto.Id,
                Name = dto.Name,
                PictureURL = dto.PicUrl,
                Rating = dto.Rating,
                NotAvailable = dto.NotAvailable,
                Ingredients = dto.Ingredients
            };
        }

        public DisplayCocktailViewModel MapFromDTO(AddCocktailDTO dto)
        {
            return new DisplayCocktailViewModel()
            {
                Name = dto.Name,
            };
        }
    }
}
