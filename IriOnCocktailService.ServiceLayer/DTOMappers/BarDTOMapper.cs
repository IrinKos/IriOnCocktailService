using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class BarDTOMapper : IDTOServiceMapper<Bar, BarDTO>,
                                IDTOServiceMapper<BarDTO,Bar>
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
                BarNotAvailable = entity.NotAvailable,
                BarRatings = entity.BarRatings.Where(bc=>bc.BarId==entity.Id).ToList(),
                BarComments = entity.BarComments.Where(bc=>bc.BarId==entity.Id).ToList()
            };
        }

        public Bar MapFrom(BarDTO barDTO)
        {
            return new Bar()
            {
                Id=barDTO.BarId,
                Address=barDTO.BarAddress,
                Name=barDTO.BarName,
                PhoneNumber=barDTO.BarPhoneNumber,
                PicUrl=barDTO.BarPicUrl,
                NotAvailable=barDTO.BarNotAvailable
            };
        }
    }
}