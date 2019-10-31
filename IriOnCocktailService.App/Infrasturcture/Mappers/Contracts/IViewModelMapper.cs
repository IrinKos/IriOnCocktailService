using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers.Contracts
{
    interface IViewModelMapper<TDTO,TViewModel>
    {
        TViewModel MapFrom(TDTO dto);
    }
}
