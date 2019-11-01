using IriOnCocktailService.Data;
using IriOnCocktailService.Data.Entities;
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

        public RoleService(IriOnCocktailServiceDbContext context, UserManager<User> roleManager)
        {
            this.context = context;
            this.userManager = roleManager;
        }

        public async Task<IList<string>> GetAllRoles()
        {
            var allRoles = await this.context.Roles.Select(r => r.Name).ToListAsync();

            return allRoles;
        }
        public async Task<User> ChangeRole(string id, string previousRole, string newRole)
        {
            var user = await userManager.FindByIdAsync(id);

            await userManager.RemoveFromRoleAsync(user, previousRole);
            await userManager.AddToRoleAsync(user, newRole);

            return user;
        }
    }
}
