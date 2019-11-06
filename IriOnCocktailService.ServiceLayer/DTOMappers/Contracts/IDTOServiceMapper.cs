using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers.Contracts
{
    public interface IDTOServiceMapper<TEntity,TDTO>
    {
        TDTO MapFrom(TEntity entity);

        //TODO Map to DTO
    }
}
