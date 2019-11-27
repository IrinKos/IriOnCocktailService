using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.App.Models;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Controllers
{
    public class CocktailController : Controller
    {
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;
        private readonly IViewModelMapper<BarDTO, BarsForCocktailViewModel> barsForCocktailMapper;
        private readonly IViewModelMapper<CocktailDTO, CocktailViewModel> cocktailViewModelMapper;
        private readonly IViewModelMapper<CommentDTO, CommentViewModel> commentMapper;

        public CocktailController(IBarService barService, ICocktailService cocktailService,
                              IViewModelMapper<BarDTO, BarViewModel> barViewModelMapper,
                                  IViewModelMapper<BarDTO, BarsForCocktailViewModel> barsForCocktailMapper,
                              IViewModelMapper<CocktailDTO, CocktailViewModel> cocktailViewModelMapper,
                              IViewModelMapper<CommentDTO, CommentViewModel> commentMapper)
        {
            this.barService = barService;
            this.cocktailService = cocktailService;
            this.barsForCocktailMapper = barsForCocktailMapper;
            this.cocktailViewModelMapper = cocktailViewModelMapper;
            this.commentMapper = commentMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cocktailsDTO = await this.cocktailService.GetAllCocktailsDTO();
            var cocktailsViewModel = new List<CocktailViewModel>();
            foreach (var cocktail in cocktailsDTO)
            {
                cocktailsViewModel.Add(this.cocktailViewModelMapper.MapFromDTO(cocktail));

            }
            cocktailsViewModel = cocktailsViewModel
                .OrderByDescending(c => c.Rating)
                    .ThenBy(c => c.Name)
                .ToList();

            return View(cocktailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var cocktailDTO = await this.cocktailService.GetCocktailDTO(id);
            var cocktailViewModel = this.cocktailViewModelMapper.MapFromDTO(cocktailDTO);
            var cocktailCommentDTOs = await this.cocktailService.GetAllCommentsForCocktail(id);
            var cocktailBars = await barService.GetAllBarsForCocktail(id);

            cocktailViewModel.Comments = cocktailCommentDTOs.Select(c => this.commentMapper.MapFromDTO(c));
            cocktailViewModel.Bars = cocktailBars.Select(cb => this.barsForCocktailMapper.MapFromDTO(cb)).ToList();

            return View(cocktailViewModel);
        }
    }
}