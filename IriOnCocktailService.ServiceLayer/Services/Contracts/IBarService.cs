using System.Collections.Generic;
using System.Threading.Tasks;
using IriOnCocktailService.ServiceLayer.DTOS;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface IBarService
    {
        Task<BarDTO> CreateBarAsync(BarDTO barDTO);
        Task DeleteBarAsync(string barId);
        Task<BarDTO> EditBarAsync(BarDTO barDTO);
        Task<BarDTO> GetBarAsync(string barId);
        Task<IReadOnlyCollection<BarDTO>> GetBarsByNameAsync(string name);
        Task<IReadOnlyCollection<BarDTO>> GetBarsByAddressAsync(string address);
        Task<ICollection<BarDTO>> GetBarsAsync();
        Task<CommentDTO> BarCommentAsync(CommentDTO barCommentDTO);
        Task<RatingDTO> BarRatingAsync(RatingDTO barRatingDTO);
        Task<ICollection<CommentDTO>> GetAllCommentsForBar(string barId);
        Task<string> GetNameForBarById(string barId);
        Task<ICollection<BarDTO>> GetAllBarsForCocktail(string id);
    }
}