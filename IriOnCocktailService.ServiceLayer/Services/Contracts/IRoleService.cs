using IriOnCocktailService.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface IRoleService
    {
        Task<IList<string>> GetAllRoles();
        Task<User> ChangeRole(string id, string previousRole, string newRole);
    }
}