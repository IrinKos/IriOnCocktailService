using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;

namespace IriOnCocktailService.App.Infrasturcture.Mappers
{
    public class CollectionViewModelMapper : IViewModelMapper<CollectionDTO, CollectionViewModel>
    {
        public CollectionViewModel MapFromDTO(CollectionDTO dto)
        {
            return new CollectionViewModel
            {
                Bars=dto.Bars
            };
        }
    }
}