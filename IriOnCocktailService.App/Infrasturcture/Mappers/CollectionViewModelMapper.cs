using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System.Collections.Generic;
using System.Linq;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CollectionViewModelMapper : IViewModelMapper<ICollection<BarDTO>, CollectionViewModel>,
        IViewModelMapper<ICollection<Cocktail>, CollectionViewModel>
    {
        private readonly IViewModelMapper<BarDTO, DisplayBarsViewModel> displayBarMapper;
        private readonly IViewModelMapper<Cocktail, DisplayCocktailViewModel> displayCocktailMapper;

        public CollectionViewModelMapper(IViewModelMapper<BarDTO, DisplayBarsViewModel> displayBarMapper,
                                        IViewModelMapper<Cocktail, DisplayCocktailViewModel> displayCocktailMapper)
        {
            this.displayBarMapper = displayBarMapper;
            this.displayCocktailMapper = displayCocktailMapper;
        }

        public CollectionViewModel MapFromDTO(ICollection<Cocktail> dto)
        {
            return new CollectionViewModel
            {
                Cocktails = dto.Select(x => this.displayCocktailMapper.MapFromDTO(x)).ToList(),
            };
        }
        public CollectionViewModel MapFromDTO(ICollection<BarDTO> dto)
        {
            return new CollectionViewModel
            {
                Bars = dto.Select(x => this.displayBarMapper.MapFromDTO(x)).ToList(),
            };
        }

    }
}