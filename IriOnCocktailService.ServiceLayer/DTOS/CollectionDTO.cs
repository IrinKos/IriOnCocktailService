using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOS
{
    public class CollectionDTO
    {
        public ICollection<BarDTO> Bars { get; set; }
    }
}
