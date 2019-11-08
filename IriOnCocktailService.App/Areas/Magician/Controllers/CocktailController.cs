using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    [Area("Magician")]
    public class CocktailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var viewModel = new CreateCocktailViewModel
            {
                SpecificIngredients = new List<AddIngredientToCocktailViewModel>()

            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCocktailViewModel viewModel)
        {
            await Task.Delay(0);
            
            return Ok();
        }
    }
}