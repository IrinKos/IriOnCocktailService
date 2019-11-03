using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class BarDTOMapper : IDTOServiceMapper<Bar, BarDTO>
    {
        public BarDTO MapFrom(Bar entity)
        {
            return new BarDTO
            {
                BarId = entity.Id,
                BarName = entity.Name,
                BarAddress = entity.Address,
                BarPhoneNumber = entity.PhoneNumber,
                BarPicUrl = entity.PicUrl,
                BarNotAvailable = entity.NotAvailable
            };
        }
    }
}