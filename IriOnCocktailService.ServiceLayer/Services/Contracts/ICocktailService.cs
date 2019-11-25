using System.Collections.Generic;
using System.Threading.Tasks;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOS;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface ICocktailService
    {
        Task<CommentDTO> CocktailCommentAsync(CommentDTO cocktailCommentDTO);
        Task<RatingDTO> CocktailRatingAsync(RatingDTO cocktailRatingDTO);
        Task<CocktailDTO> CreateCocktail(CocktailDTO cocktailDTO);
        Task<ICollection<CocktailDTO>> GetAllCocktailsDTO();
        Task<ICollection<AddCocktailDTO>> GetAllContainedCocktailsDTO(string barId);
        Task<ICollection<AddCocktailDTO>> GetAllNotContainedCocktailsDTO(string barId);
        Task<ICollection<CocktailDTO>> GetAllCocktailsByNameDTO(string name);
        Task<Cocktail> GetCocktail(string id);
        Task<CocktailDTO> GetCocktailDTO(string id);
        Task<ICollection<CommentDTO>> GetAllCommentsForCocktail(string cocktailId);
        Task<ICollection<CocktailDTO>> GetAllCocktailsByIngredientDTO(string ingredient);
        Task<CocktailDTO> EditCocktailAsync(CocktailDTO cocktailDTO);
        Task DeleteCocktailAsync(string Id);
    }
}