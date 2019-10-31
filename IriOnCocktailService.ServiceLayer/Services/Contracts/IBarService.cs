using System.Threading.Tasks;
using IriOnCocktailService.ServiceLayer.DTOS;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface IBarService
    {
        Task<BarDTO> CreateBar(BarDTO barDTO);
        Task<BarDTO> GetBar(string barId);
    }
}