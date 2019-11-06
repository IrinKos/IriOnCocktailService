using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers.Contracts
{
    public interface IViewModelMapper<TDTO,TViewModel>
    {
        TViewModel MapFromDTO(TDTO dto);
    }
}
