using System.Collections.Generic;
using System.Threading.Tasks;
using IriOnCocktailService.ServiceLayer.DTOS;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface ICocktailIngredientService
    {
        Task<List<CocktailIngredientDTO>> CreateCocktailIngredient(List<CocktailIngredientDTO> cocktailIngredientDTOs);
    }
}