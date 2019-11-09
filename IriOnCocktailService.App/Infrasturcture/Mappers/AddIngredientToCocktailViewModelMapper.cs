using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class AddIngredientToCocktailViewModelMapper : IDTOMapper<AddIngredientToCocktailViewModel, CocktailIngredientDTO>
    {
        public CocktailIngredientDTO MapFromViewModel(AddIngredientToCocktailViewModel viewModel)
        {
            return new CocktailIngredientDTO()
            {
                Quantity=viewModel.Quantity,
                UnitType=viewModel.Unit,
                IngredientId=viewModel.IngredientId
            };
        }
    }
}
