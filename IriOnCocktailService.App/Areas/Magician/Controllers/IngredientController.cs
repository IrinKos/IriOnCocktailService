using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    [Area("Magician")]
    [Authorize(Roles = "CocktailMagician")]
    public class IngredientController : Controller
    {
        private readonly IIngredientService ingredientService;
        private readonly IDTOMapper<CreateIngredientViewModel, IngredientDTO> ingredientToDTOMpper;
        private readonly IViewModelMapper<IngredientDTO, CreateIngredientViewModel> ingredientToVMMapper;

        public IngredientController(IIngredientService ingredientService,
                                    IViewModelMapper<IngredientDTO, CreateIngredientViewModel> ingredientToVMMapper,
                                    IDTOMapper<CreateIngredientViewModel, IngredientDTO> ingredientMpper)
        {
            this.ingredientService = ingredientService;
            this.ingredientToDTOMpper = ingredientMpper;
            this.ingredientToVMMapper = ingredientToVMMapper;
        }
        public async Task<IActionResult> Index()
        {
            var ingredients = await this.ingredientService.GetAllIngredients();
            var ingredientsViewModel = new List<CreateIngredientViewModel>();

            foreach (var ingredientVM in ingredients)
            {
                ingredientsViewModel.Add(this.ingredientToVMMapper.MapFromDTO(ingredientVM));
            }
            return View(ingredientsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIngredientViewModel vm)
        {
            var ingredientDTO = this.ingredientToDTOMpper.MapFromViewModel(vm);
            await this.ingredientService.CreateIngredient(ingredientDTO);

            return RedirectToAction("Index", "Ingredient");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id) // <-- Ingredient Id
        {
            if (id == null)
                return NotFound();

            var ingredientDTO = await this.ingredientService.GetIngredientDTO(id);
            var ingredientVM = this.ingredientToVMMapper.MapFromDTO(ingredientDTO);

            return View(ingredientVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateIngredientViewModel ingredientVM) 
        {
            var ingredient = await this.ingredientService.UpdateIngredient(ingredientVM.Id, ingredientVM.Name);

            return RedirectToAction("Index", "Ingredient");
        }
    }
}