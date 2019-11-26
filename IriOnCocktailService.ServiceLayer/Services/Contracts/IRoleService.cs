using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOS;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services.Contracts
{
    public interface IRoleService
    {
        Task<IList<string>> GetAllRoles();
        Task<User> ChangeRole(UserDTO userDTO);
        Task<IEnumerable<UserDTO>> GetAllUsers();
    }
}