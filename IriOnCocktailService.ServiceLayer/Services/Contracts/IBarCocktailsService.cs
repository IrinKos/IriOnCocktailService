using System.Collections.Generic;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface IBarCocktailsService
    {
        Task Add(List<string> cocktails, string barId);
        Task Remove(List<string> cocktails, string barId);
    }
}