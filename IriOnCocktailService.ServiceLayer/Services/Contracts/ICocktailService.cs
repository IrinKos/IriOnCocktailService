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
        Task<DTOS.Cocktail> CreateCocktail(DTOS.Cocktail cocktailDTO);
        Task<ICollection<DTOS.Cocktail>> GetAllCocktailsDTO();
        Task<ICollection<AddCocktailDTO>> GetAllContainedCocktailsDTO(string barId);
        Task<ICollection<AddCocktailDTO>> GetAllNotContainedCocktailsDTO(string barId);
        Task<ICollection<DTOS.Cocktail>> GetAllCocktailsByNameDTO(string name);
        Task<Data.Entities.Cocktail> GetCocktail(string id);
        Task<DTOS.Cocktail> GetCocktailDTO(string id);
        Task<ICollection<CommentDTO>> GetAllCommentsForCoctail(string cocktailId);
        Task<ICollection<DTOS.Cocktail>> GetAllCocktailsByIngredientDTO(string ingredient);
    }
}