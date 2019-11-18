using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.App.Models;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IriOnCocktailService.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;
        private readonly IViewModelMapper<BarDTO, BarViewModel> barViewModelMapper;
        private readonly IViewModelMapper<CocktailDTO, CocktailViewModel> cocktailViewModelMapper;

        public HomeController(IBarService barService, ICocktailService cocktailService,
                              IViewModelMapper<BarDTO, BarViewModel> barViewModelMapper, 
                              IViewModelMapper<CocktailDTO, CocktailViewModel> cocktailViewModelMapper)
        {
            this.barService = barService;
            this.cocktailService = cocktailService;
            this.barViewModelMapper = barViewModelMapper;
            this.cocktailViewModelMapper = cocktailViewModelMapper;
        }

        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("BarCrawler"))
                return Redirect("~/Crawler/Home/Index");

            else if (User.IsInRole("CocktailMagician"))
                return Redirect("~/Magician/Home/Index");

            var barsDTO = await this.barService.GetBarsAsync();
            var barsViewModel = new List<BarViewModel>();
            foreach (var bar in barsDTO)
            {
                barsViewModel.Add(this.barViewModelMapper.MapFromDTO(bar));
            }
            barsViewModel = barsViewModel
                .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                .Take(4)
                .ToList();

            var cocktailsDTO = await this.cocktailService.GetAllCocktailsDTO();
            var cocktailsViewModel = new List<CocktailViewModel>();
            foreach (var cocktail in cocktailsDTO)
            {
                cocktailsViewModel.Add(this.cocktailViewModelMapper.MapFromDTO(cocktail));
            }
            cocktailsViewModel = cocktailsViewModel
                .OrderByDescending(c => c.Rating)
                    .ThenBy(c => c.Name)
                .Take(4)
                .ToList();

            var viewModel = new IndexViewModel();
            viewModel.Bars = barsViewModel;
            viewModel.Cocktails = cocktailsViewModel;

            return View(viewModel);
        }

        public async Task<IActionResult> Bars([FromQuery] string name)
        {
            var bars = await this.barService
                .GetBarsByNameAsync(name); 

            var barsVM = new List<BarViewModel>();
            foreach (var bar in bars)
            {
                barsVM.Add(this.barViewModelMapper.MapFromDTO(bar));
            }

            return PartialView("_SearchPartial", barsVM);
        }

        public async Task<IActionResult> BarsAddress([FromQuery] string address) 
        {
            var bars = await this.barService.GetBarsByAddressAsync(address);

            var barsVM = new List<BarViewModel>();
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

            var cocktailsVM = new List<CocktailViewModel>();
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

            var cocktailsVM = new List<CocktailViewModel>();
            foreach (var cocktail in cocktails)
            {
                cocktailsVM.Add(this.cocktailViewModelMapper.MapFromDTO(cocktail));
            }

            return PartialView("_SearchCoctailPartial", cocktailsVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
