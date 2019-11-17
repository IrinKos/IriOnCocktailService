using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class AddCocktailsToBarViewModelMapper : IViewModelMapper<BarDTO, AddCocktailsToBarViewModel>
    {
        public AddCocktailsToBarViewModel MapFromDTO(BarDTO dto)
        {
            return new AddCocktailsToBarViewModel();
            //{
            //    CocktailsToAdd = 
            //    CocktailsToRemove = dto.BarNotAvailableCocktails.Select(cta => new SelectListItem(cta.Cocktail.Name, cta.CocktailId)),
            //};
        }
    }
}
