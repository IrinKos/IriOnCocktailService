using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    public class CocktailDTOMapper : IDTOServiceMapper<Cocktail, CocktailDTO>
    {
        public CocktailDTO MapFrom(Cocktail entity)
        {
            return new CocktailDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                PicUrl = entity.PicUrl,
                NotAvailable = entity.NotAvailable
            };
        }
    }
}
