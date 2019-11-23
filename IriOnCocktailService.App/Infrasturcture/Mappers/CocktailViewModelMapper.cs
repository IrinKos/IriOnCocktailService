using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.App.Models;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CocktailViewModelMapper : IViewModelMapper<CocktailDTO, CocktailViewModel>
    {
        public CocktailViewModel MapFromDTO(CocktailDTO dto)
        {
            return new CocktailViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                PictureURL = dto.PicUrl,
                Rating = dto.Rating,
                Motto = dto.Motto,
                NotAvailable = dto.NotAvailable,
                Ingredients = dto.Ingredients,
            };
        }
    }
}
