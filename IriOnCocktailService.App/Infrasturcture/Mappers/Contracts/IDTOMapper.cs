using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Infrasturcture.Mappers.Contracts
{
    public interface IDTOMapper<TViewModel,TDTO>
    {
        TDTO MapFromViewModel(TViewModel viewModel);
    }
}
