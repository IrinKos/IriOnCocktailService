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
        public CreateIngredientViewModel MapFrom(IngredientDTO ingredientDTO)
        {
            return new CreateIngredientViewModel
            {
                Name = ingredientDTO.Name
            };
        }

        public IngredientDTO MapFrom(CreateIngredientViewModel viewModel)
        {
            return new IngredientDTO
            {
                Name = viewModel.Name
            };
        }
    }
}
