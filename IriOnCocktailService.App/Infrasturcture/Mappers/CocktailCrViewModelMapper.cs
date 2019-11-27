using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CocktailCrViewModelMapper : IViewModelMapper<CocktailDTO, CocktailCrViewModel>
    {
        public CocktailCrViewModel MapFromDTO(CocktailDTO dto)
        {
            return new CocktailCrViewModel
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
