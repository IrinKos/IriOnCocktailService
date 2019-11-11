using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System.Collections.Generic;
using System.Linq;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CollectionViewModelMapper : IViewModelMapper<ICollection<BarDTO>, CollectionViewModel>
    {
        private readonly IViewModelMapper<BarDTO, DisplayBarsViewModel> displayBarMapper;

        public CollectionViewModelMapper(IViewModelMapper<BarDTO, DisplayBarsViewModel> displayBarMapper)
        {
            this.displayBarMapper = displayBarMapper;
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