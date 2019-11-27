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
    public class BarController : Controller
    {
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;
        private readonly IViewModelMapper<ICollection<BarDTO>, CollectionViewModel> collectionMapper;
        private readonly IViewModelMapper<BarDTO, DisplayBarsViewModel> barViewModelMapper;
        private readonly IDTOMapper<CommentViewModel, CommentDTO> barCommentMapper;
        private readonly IViewModelMapper<CommentDTO, CommentViewModel> commentMapper;
        private readonly IViewModelMapper<AddCocktailDTO, CocktailsForBarViewModel> cocktailsForBarMapper;
        private readonly IViewModelMapper<BarDTO, BarDetailsViewModel> barDetailsMapper;
        private readonly IDTOMapper<RatingViewModel, RatingDTO> barRatingMapper;

        public BarController(IBarService barService,
                             ICocktailService cocktailService,
                             IViewModelMapper<ICollection<BarDTO>, CollectionViewModel> collectionMapper,
                             IViewModelMapper<BarDTO,DisplayBarsViewModel> barViewModelMapper,
                             IDTOMapper<CommentViewModel, CommentDTO> barCommentMapper, 
                             IViewModelMapper<CommentDTO, CommentViewModel> commentMapper,
                             IViewModelMapper<AddCocktailDTO, CocktailsForBarViewModel> cocktailsForBarMapper,
                             IViewModelMapper<BarDTO, BarDetailsViewModel> barDetailsMapper,
                             IDTOMapper<RatingViewModel, RatingDTO> barRatingMapper)
        {
            this.barService = barService;
            this.cocktailService = cocktailService;
            this.collectionMapper = collectionMapper;
            this.barViewModelMapper = barViewModelMapper;
            this.barCommentMapper = barCommentMapper;
            this.commentMapper = commentMapper;
            this.cocktailsForBarMapper = cocktailsForBarMapper;
            this.barDetailsMapper = barDetailsMapper;
            this.barRatingMapper = barRatingMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var barsDto = await this.barService.GetBarsAsync();
            var viewModel = this.collectionMapper.MapFromDTO(barsDto);

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            var barDTO = await this.barService.GetBarAsync(Id);
            var barViewModel = this.barDetailsMapper.MapFromDTO(barDTO);

            var commentsDTO = await barService.GetAllCommentsForBar(Id);
            var cocktailsDTO = await cocktailService.GetAllContainedCocktailsDTO(Id);

            barViewModel.Comments = commentsDTO.Select(c=> commentMapper.MapFromDTO(c));
            barViewModel.Cocktails = cocktailsDTO.Select(c => cocktailsForBarMapper.MapFromDTO(c)).ToList();

            return View(barViewModel);
        }
        [HttpGet]
        public IActionResult Comment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel barCommentViewModel)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            barCommentViewModel.UserId = userId;
            barCommentViewModel.CreatedOn = DateTime.Now.ToString();
            var barCommentDTO = this.barCommentMapper.MapFromViewModel(barCommentViewModel);
            await this.barService.BarCommentAsync(barCommentDTO);

            return Ok();
        }
        [HttpGet]
        public IActionResult Rating()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Rating(RatingViewModel barRatingViewModel)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            barRatingViewModel.UserId = userId;
            var barRatingDTO = this.barRatingMapper.MapFromViewModel(barRatingViewModel);
            await this.barService.BarRatingAsync(barRatingDTO);

            return RedirectToAction("Index","Bar");
        }
        [HttpGet]
        public async Task<IActionResult> GetComments(string barId)
        {
            //    //CommentViewModel barCommentViewModel
            //    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //    var commentDTOs = this.barService.GetAllForBarComments(barId);
            //    var barRatingDTO = this.barRatingMapper.MapFromViewModel(barRatingViewModel);
            //    await this.barService.BarRatingAsync(barRatingDTO);
            await Task.Delay(0);
            return Ok();
        }
    }
}