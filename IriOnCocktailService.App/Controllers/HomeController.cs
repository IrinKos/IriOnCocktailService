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
                barsViewModel.Add(barViewModelMapper.MapFromDTO(bar));
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
                cocktailsViewModel.Add(cocktailViewModelMapper.MapFromDTO(cocktail));
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
