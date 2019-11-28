using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Crawler.Controllers
{
    [Area("Crawler")]
    [Authorize(Roles = "BarCrawler")]
    public class CocktailController : Controller
    {
        private readonly ICocktailService cocktailService;
        private readonly IBarService barService;
        private readonly IViewModelMapper<CocktailDTO, App.Models.CocktailViewModel> cocktailViewModelMapper;
        private readonly IViewModelMapper<CommentDTO, App.Models.CommentViewModel> commentMapper;
        private readonly IViewModelMapper<BarDTO, BarsForCocktailViewModel> barsForCocktailMapper;
        private readonly IViewModelMapper<ICollection<CocktailDTO>, CollectionViewModel> collectionMapper;
        private readonly IDTOMapper<CommentViewModel, CommentDTO> cocktailCommentMapper;
        private readonly IDTOMapper<RatingViewModel, RatingDTO> cocktailRatingMapper;

        public CocktailController(ICocktailService cocktailService,
                                  IBarService barService,
                                  IViewModelMapper<CocktailDTO, App.Models.CocktailViewModel> cocktailViewModelMapper,
                                  IViewModelMapper<CommentDTO, App.Models.CommentViewModel> commentMapper,
                                  IViewModelMapper<BarDTO, BarsForCocktailViewModel> barsForCocktailMapper,

                             IViewModelMapper<ICollection<CocktailDTO>, CollectionViewModel> collectionMapper,
                             IDTOMapper<CommentViewModel, CommentDTO> cocktailCommentMapper,
                             IDTOMapper<RatingViewModel, RatingDTO> cocktailRatingMapper
                             )
        {
            this.cocktailService = cocktailService;
            this.barService = barService;
            this.cocktailViewModelMapper = cocktailViewModelMapper;
            this.commentMapper = commentMapper;
            this.barsForCocktailMapper = barsForCocktailMapper;
            this.collectionMapper = collectionMapper;
            this.cocktailCommentMapper = cocktailCommentMapper;
            this.cocktailRatingMapper = cocktailRatingMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var barsDto = await this.cocktailService.GetAllCocktailsDTO();
            var viewModel = this.collectionMapper.MapFromDTO(barsDto);

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var cocktailDTO = await this.cocktailService.GetCocktailDTO(id);
            var cocktailViewModel = this.cocktailViewModelMapper.MapFromDTO(cocktailDTO);
            var cocktailCommentDTOs = await this.cocktailService.GetAllCommentsForCocktail(id);
            var cocktailBars = await barService.GetAllBarsForCocktail(id);

            cocktailViewModel.Comments = cocktailCommentDTOs.Select(c => this.commentMapper.MapFromDTO(c)).ToList();
            cocktailViewModel.Bars = cocktailBars.Select(cb => this.barsForCocktailMapper.MapFromDTO(cb)).ToList();

            return View(cocktailViewModel);
        }
        [HttpGet]
        public IActionResult Comment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel cocktailCommentViewModel)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            cocktailCommentViewModel.UserId = userId;

            var barCommentDTO = this.cocktailCommentMapper.MapFromViewModel(cocktailCommentViewModel);
            await this.cocktailService.CocktailCommentAsync(barCommentDTO);

            return Ok();
        }
        [HttpGet]
        public IActionResult Rating()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Rating(RatingViewModel cocktailRatingViewModel)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            cocktailRatingViewModel.UserId = userId;

            var barRatingDTO = this.cocktailRatingMapper.MapFromViewModel(cocktailRatingViewModel);
            await this.cocktailService.CocktailRatingAsync(barRatingDTO);

            return Ok();
        }
        
    }
}