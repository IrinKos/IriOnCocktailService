using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    [Area("Magician")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IRoleService roleService;

        public UserController(UserManager<User> userManager, IRoleService roleService)
        {
            this.userManager = userManager;
            this.roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> Promote(string Id)
        {
            var user = await this.userManager.FindByIdAsync(Id);
            var roles = (await this.roleService.GetAllRoles()).Select(r=> new SelectListItem(r,r)).ToList();
            var viewModel = new ChangeRoleViewModel
            {
                Id=Id,
                currentRole = (await this.userManager.GetRolesAsync(user))[0],
                allRoles = roles
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Promote(ChangeRoleViewModel viewModel)
        {
            var user = await this.roleService.ChangeRole(viewModel.Id, viewModel.currentRole, viewModel.newRole);

            //TODO remove Ok()
            return Ok(user);
        }
    }
}