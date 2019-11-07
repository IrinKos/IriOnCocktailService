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
        Task<Cocktail> GetCocktail(string id);
        Task<CocktailDTO> GetCocktailDTO(string id);
    }
}