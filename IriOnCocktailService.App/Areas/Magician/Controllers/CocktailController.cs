using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.ServiceLayer.Services;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    [Area("Magician")]
    public class CocktailController : Controller
    {
        private readonly ICocktailService cocktailService;
        private readonly IIngredientService ingredientService;

        public CocktailController(ICocktailService cocktailService,
                                  IIngredientService ingredientService)
        {
            this.cocktailService = cocktailService;
            this.ingredientService = ingredientService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var allIngredients = (await ingredientService.GetAllIngredients()).Select(i => new SelectListItem(i.Name,i.Id)).ToList();

            var viewModel = new CreateCocktailViewModel
            {
                SpecificIngredients = new List<AddIngredientToCocktailViewModel>(),
                AllIngredients=allIngredients
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCocktailViewModel viewModel)
        {

            await Task.Delay(0);
           // cocktailService.CreateCocktail()
            return Ok();
        }
    }
}