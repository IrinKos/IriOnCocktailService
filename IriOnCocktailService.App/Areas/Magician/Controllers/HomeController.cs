using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    [Area("Magician")]
    [Authorize(Roles = "CocktailMagician")]
    public class HomeController : Controller
    {
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;
        private readonly IViewModelMapper<BarDTO, DisplayBarsViewModel> barViewModelMapper;
        private readonly IViewModelMapper<CocktailDTO, DisplayCocktailViewModel> cocktailViewModelMapper;

        public HomeController(IBarService barService, ICocktailService cocktailService,
                              IViewModelMapper<BarDTO, DisplayBarsViewModel> barViewModelMapper,
                              IViewModelMapper<CocktailDTO, DisplayCocktailViewModel> cocktailViewModelMapper)
        {
            this.barService = barService;
            this.cocktailService = cocktailService;
            this.barViewModelMapper = barViewModelMapper;
            this.cocktailViewModelMapper = cocktailViewModelMapper;
        }
        public async Task<IActionResult> Index()
        {
            var barsDTO = await this.barService.GetBarsAsync();
            var barsViewModel = new List<DisplayBarsViewModel>();
            foreach (var bar in barsDTO)
            {
                barsViewModel.Add(this.barViewModelMapper.MapFromDTO(bar));
            }
            barsViewModel = barsViewModel
                .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                .Take(6)
                .ToList();

            var cocktailsDTO = await this.cocktailService.GetAllCocktailsDTO();
            var cocktailsViewModel = new List<DisplayCocktailViewModel>();
            foreach (var cocktail in cocktailsDTO)
            {
                cocktailsViewModel.Add(this.cocktailViewModelMapper.MapFromDTO(cocktail));
            }
            cocktailsViewModel = cocktailsViewModel
                .OrderByDescending(c => c.Rating)
                    .ThenBy(c => c.Name)
                .Take(6)
                .ToList();

            var viewModel = new IndexMagViewModel(); 
            viewModel.Bars = barsViewModel;
            viewModel.Cocktails = cocktailsViewModel;

            return View(viewModel);
        }
        public async Task<IActionResult> Bars([FromQuery] string name)
        {
            var bars = await this.barService
                .GetBarsByNameAsync(name);

            var barsVM = new List<DisplayBarsViewModel>();
            foreach (var bar in bars)
            {
                barsVM.Add(this.barViewModelMapper.MapFromDTO(bar));
            }

            return PartialView("_SearchPartial", barsVM);
        }
        public async Task<IActionResult> BarsAddress([FromQuery] string address)
        {
            var bars = await this.barService.GetBarsByAddressAsync(address);

            var barsVM = new List<DisplayBarsViewModel>();
            foreach (var bar in bars)
            {
                barsVM.Add(this.barViewModelMapper.MapFromDTO(bar));
            }

            return PartialView("_SearchPartial", barsVM);
        }

        public async Task<IActionResult> Cocktails([FromQuery] string name)
        {
            var cocktails = await this.cocktailService
                .GetAllCocktailsByNameDTO(name);

            var cocktailsVM = new List<DisplayCocktailViewModel>();
            foreach (var cocktail in cocktails)
            {
                cocktailsVM.Add(this.cocktailViewModelMapper.MapFromDTO(cocktail));
            }

            return PartialView("_SearchCoctailPartial", cocktailsVM);
        }
        public async Task<IActionResult> CocktailsIngredients([FromQuery] string ingredient)
        {
            var cocktails = await this.cocktailService
                .GetAllCocktailsByIngredientDTO(ingredient);

            var cocktailsVM = new List<DisplayCocktailViewModel>();
            foreach (var cocktail in cocktails)
            {
                cocktailsVM.Add(this.cocktailViewModelMapper.MapFromDTO(cocktail));
            }

            return PartialView("_SearchCoctailPartial", cocktailsVM);
        }
    }
}