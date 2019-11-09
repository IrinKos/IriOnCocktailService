using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CreateIngredientViewModelMapper : IViewModelMapper<IngredientDTO, CreateIngredientViewModel>,
                                               IDTOMapper<CreateIngredientViewModel, IngredientDTO>
    {
        public CreateIngredientViewModel MapFromDTO(IngredientDTO ingredientDTO)
        {
            return new CreateIngredientViewModel
            {
                Id = ingredientDTO.Id,
                Name = ingredientDTO.Name,
                UnitType = ingredientDTO.UnitType,
                IsDeleted = ingredientDTO.IsDeleted
            };
        }

        public IngredientDTO MapFromViewModel(CreateIngredientViewModel viewModel)
        {
            return new IngredientDTO
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                UnitType = viewModel.UnitType,
                IsDeleted = viewModel.IsDeleted
            };
        }
    }
}
