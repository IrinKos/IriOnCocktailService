using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers
{
    class AddCocktailDTOMapper : IDTOServiceMapper<Cocktail, AddCocktailDTO>
    {
        public AddCocktailDTO MapFrom(Cocktail entity)
        {
            return new AddCocktailDTO
            {
                Id=entity.Id,
                Name=entity.Name,
                PicUrl=entity.PicUrl,
            };
        }
    }
}
