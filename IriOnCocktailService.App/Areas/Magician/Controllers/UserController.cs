using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.Data.Entities;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    [Area("Magician")]
    [Authorize(Roles = "CocktailMagician")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IRoleService roleService;
        private readonly IDTOMapper<ChangeRoleViewModel, UserDTO> changerRoleMapper;

        public UserController(UserManager<User> userManager, 
                              IRoleService roleService,
                              IDTOMapper<ChangeRoleViewModel, UserDTO> changerRoleMapper)
        {
            this.userManager = userManager;
            this.roleService = roleService;
            this.changerRoleMapper = changerRoleMapper;
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
            var userDTO = changerRoleMapper.MapFromViewModel(viewModel);
            var user = await this.roleService.ChangeRole(userDTO);

            //TODO remove Ok()
            return Ok(user);
        }
    }
}