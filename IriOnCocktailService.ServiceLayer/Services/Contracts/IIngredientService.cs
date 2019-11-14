using System.Collections.Generic;
using System.Threading.Tasks;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOS;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface IIngredientService
    {
        Task<IngredientDTO> CreateIngredient(IngredientDTO ingredientDTO);
        Task DeleteIngredient(string id);
        Task<ICollection<IngredientDTO>> GetAllIngredients();
        Task<Ingredient> GetIngredient(string ingredientId);
        Task<IngredientDTO> GetIngredientDTO(string ingredientId);
        Task<string> GetUnitType(string id);
        Task<Ingredient> UpdateIngredient(string id, string newName);
    }
}