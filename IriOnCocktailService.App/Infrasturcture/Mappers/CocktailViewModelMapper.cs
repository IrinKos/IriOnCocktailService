using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.App.Models;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CocktailViewModelMapper : IViewModelMapper<Cocktail, CocktailViewModel>
    {
        public CocktailViewModel MapFromDTO(Cocktail dto)
        {
            return new CocktailViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                PictureURL = dto.PicUrl,
                Rating = dto.Rating,
                NotAvailable = dto.NotAvailable,
                Ingredients = dto.Ingredients,
            };
        }
    }
}
