using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOMappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IriOnCocktailService.ServiceLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly IriOnCocktailServiceDbContext context;
        private readonly UserManager<User> userManager;
        private readonly IDTOServiceMapper<User, UserDTO> userDTOMapper;

        public RoleService(IriOnCocktailServiceDbContext context, UserManager<User> roleManager, IDTOServiceMapper<User, UserDTO> userDTOMapper)
        {
            this.context = context;
            this.userManager = roleManager;
            this.userDTOMapper = userDTOMapper;
        }

        public async Task<IList<string>> GetAllRoles()
        {
            var allRoles = await this.context.Roles.Select(r => r.Name).ToListAsync();

            return allRoles;
        }
        public async Task<User> ChangeRole(UserDTO dto)
        {
            var user = await userManager.FindByIdAsync(dto.Id);

            await userManager.RemoveFromRoleAsync(user, dto.CurrentRole);
            await userManager.AddToRoleAsync(user, dto.NewRole);

            return user;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return (await this.context.Users.ToListAsync()).Select(u=>userDTOMapper.MapFrom(u)).ToList();
        }
    }
}
