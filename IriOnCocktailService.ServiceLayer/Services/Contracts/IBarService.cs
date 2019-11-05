using System.Threading.Tasks;
using IriOnCocktailService.ServiceLayer.DTOS;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface IBarService
    {
        Task<BarDTO> CreateBarAsync(BarDTO barDTO);
        Task DeleteBarAsync(string barId);
        Task<BarDTO> EditBarAsync(BarDTO dto);
        Task<BarDTO> GetBarAsync(string barId);
        Task<CollectionDTO> GetBarsAsync();
    }
}