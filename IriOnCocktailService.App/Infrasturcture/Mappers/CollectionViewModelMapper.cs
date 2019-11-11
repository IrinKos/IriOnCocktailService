using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System.Collections.Generic;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CollectionViewModelMapper : IViewModelMapper<ICollection<BarDTO>, CollectionViewModel>
    {
        public CollectionViewModel MapFromDTO(CollectionDTO dto)
        {
            return new CollectionViewModel
            {
                Bars=dto.Bars
            };
        }

        public CollectionViewModel MapFromDTO(ICollection<BarDTO> dto)
        {
            return new CollectionViewModel
            {
                Bars = dto
            };
        }
    }
}