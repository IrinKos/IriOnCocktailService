using System;
using System.Collections.Generic;
using System.Text;

namespace IriOnCocktailService.ServiceLayer.DTOMappers.Contracts
{
    public interface IDTOMapper<TEntity,TDTO>
    {
        TDTO MapFrom(TEntity entity);
    }
}
