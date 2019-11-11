using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CreateCocktailViewModelMapper : IDTOMapper<CreateCocktailViewModel, CocktailDTO>
    {
        private readonly IDTOMapper<AddIngredientToCocktailViewModel, CocktailIngredientDTO> mapper;

        public CreateCocktailViewModelMapper(IDTOMapper<AddIngredientToCocktailViewModel, CocktailIngredientDTO> mapper)
        {
            this.mapper = mapper;
        }

        public CreateCocktailViewModel MapFromDTO(CocktailDTO cocktailDTO)
        {
            return new CreateCocktailViewModel
            {
                
            };
        }
        public CocktailDTO MapFromViewModel(CreateCocktailViewModel viewModel)
        {
            return new CocktailDTO
            {
                Name = viewModel.CocktailName,
                Ingredients = viewModel.SpecificIngredients.Select(x => mapper.MapFromViewModel(x)).ToList(),
            };
        }
    }
}
