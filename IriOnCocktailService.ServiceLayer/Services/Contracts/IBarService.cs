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
        Task<ICollection<BarDTO>> GetBarsAsync();
        Task<CommentDTO> BarCommentAsync(CommentDTO barCommentDTO);
        Task<RatingDTO> BarRatingAsync(RatingDTO barRatingDTO);
    }
}