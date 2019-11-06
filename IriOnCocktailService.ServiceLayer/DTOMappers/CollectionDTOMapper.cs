using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers.Registration
{
    class CollectionDTOMapper : IDTOServiceMapper<ICollection<Bar>, CollectionDTO>
    {
        private readonly IDTOServiceMapper<Bar, BarDTO> barMapper;

        public CollectionDTOMapper(IDTOServiceMapper<Bar, BarDTO> barMapper)
        {
            this.barMapper = barMapper;
        }
        public CollectionDTO MapFrom(ICollection<Bar> bars)
        {
            return new CollectionDTO()
            {
                Bars = bars.Select(this.barMapper.MapFrom).ToList()
            };
        }
    }
}
