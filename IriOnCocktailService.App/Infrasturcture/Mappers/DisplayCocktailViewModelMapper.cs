using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class DisplayCocktailViewModelMapper : IViewModelMapper<Cocktail, DisplayCocktailViewModel>
    {
        public DisplayCocktailViewModel MapFromDTO(Cocktail dto)
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
    }
}
