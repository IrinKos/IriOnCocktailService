using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CreateCocktailViewModelMapper : IDTOMapper<CreateCocktailViewModel, Cocktail>
    {
        private readonly IDTOMapper<AddIngredientToCocktailViewModel, CocktailIngredientDTO> mapper;

        public CreateCocktailViewModelMapper(IDTOMapper<AddIngredientToCocktailViewModel, CocktailIngredientDTO> mapper)
        {
            this.mapper = mapper;
        }

        public CreateCocktailViewModel MapFromDTO(Cocktail cocktailDTO)
        {
            return new CreateCocktailViewModel
            {
                
            };
        }
        public Cocktail MapFromViewModel(CreateCocktailViewModel viewModel)
        {
            return new Cocktail
            {
                Name = viewModel.CocktailName,
                PicUrl = viewModel.PicUrl,
                Ingredients = viewModel.SpecificIngredients.Select(x => mapper.MapFromViewModel(x)).ToList(),
            };
        }
    }
}
