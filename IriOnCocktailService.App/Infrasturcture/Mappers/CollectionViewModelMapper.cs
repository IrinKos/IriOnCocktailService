using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System.Collections.Generic;
using System.Linq;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CollectionViewModelMapper : IViewModelMapper<ICollection<BarDTO>, CollectionViewModel>,
        IViewModelMapper<ICollection<CocktailDTO>, CollectionViewModel>
    {
        private readonly IViewModelMapper<BarDTO, DisplayBarsViewModel> displayBarMapper;
        private readonly IViewModelMapper<CocktailDTO, DisplayCocktailViewModel> displayCocktailMapper;

        public CollectionViewModelMapper(IViewModelMapper<BarDTO, DisplayBarsViewModel> displayBarMapper,
                                        IViewModelMapper<CocktailDTO, DisplayCocktailViewModel> displayCocktailMapper)
        {
            this.displayBarMapper = displayBarMapper;
            this.displayCocktailMapper = displayCocktailMapper;
        }

        public CollectionViewModel MapFromDTO(ICollection<CocktailDTO> dto)
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