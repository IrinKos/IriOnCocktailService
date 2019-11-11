using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
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
        private readonly IDTOMapper<CreateCocktailViewModel, CocktailDTO> createCocktailMapper;
        private readonly IViewModelMapper<IngredientDTO, CreateIngredientViewModel> ingredientMapper;

        public CocktailController(ICocktailService cocktailService,
                                  IIngredientService ingredientService,
                                  IDTOMapper<CreateCocktailViewModel, CocktailDTO> createCocktailMapper,
                                  IViewModelMapper<IngredientDTO, CreateIngredientViewModel> ingredientMapper)
        {
            this.cocktailService = cocktailService;
            this.ingredientService = ingredientService;
            this.createCocktailMapper = createCocktailMapper;
            this.ingredientMapper = ingredientMapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var allIngredients = (await ingredientService.GetAllIngredients()).Select(i => new SelectListItem(i.Name,i.Id)).ToList();
            var unitTypes = (await ingredientService.GetAllIngredients()).Select(i => new SelectListItem(i.UnitType, i.Id)).ToList();
            var a = (await ingredientService.GetAllIngredients()).Select(i => this.ingredientMapper.MapFromDTO(i)).ToList();
            var viewModel = new CreateCocktailViewModel
            {
                SpecificIngredients = new List<AddIngredientToCocktailViewModel>(),
                AllIngredients=allIngredients,
                AllUnitTypes=unitTypes,
                AllAllIngredients= a
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCocktailViewModel viewModel)
        {
            var dto = this.createCocktailMapper.MapFromViewModel(viewModel);
            await this.cocktailService.CreateCocktail(dto);

           // cocktailService.CreateCocktail()
            return Ok();
        }
        [HttpPost]
        public async Task<string> SetIngredientUnit(string id)
        {
            //TODO find the fucking unity // credits : iwaka
            return "Milliliters";
        }
    }
}