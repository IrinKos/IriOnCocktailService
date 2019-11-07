using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Crawler.Controllers
{
    public class BarController : Controller
    {
        private readonly IBarService barService;
        private readonly IViewModelMapper<CollectionDTO, CollectionViewModel> collectionMapper;
        private readonly IDTOMapper<BarCommentViewModel, BarCommentDTO> barCommentMapper;
        private readonly IDTOMapper<BarRatingViewModel, BarRatingDTO> barRatingMapper;

        public BarController(IBarService barService,
                             IViewModelMapper<CollectionDTO, CollectionViewModel> collectionMapper,
                             IDTOMapper<BarCommentViewModel, BarCommentDTO> barCommentMapper,
                             IDTOMapper<BarRatingViewModel, BarRatingDTO> barRatingMapper)
        {
            this.barService = barService;
            this.collectionMapper = collectionMapper;
            this.barCommentMapper = barCommentMapper;
            this.barRatingMapper = barRatingMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var barsDto = await this.barService.GetBarsAsync();
            //var viewModel = this.collectionMapper.MapFromDTO(barsDto);
            return View(/*viewModel*/);
        }
        [HttpGet]
        public async Task<IActionResult> Comment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Comment(BarCommentViewModel barCommentViewModel)
        {
            var barCommentDTO = this.barCommentMapper.MapFromViewModel(barCommentViewModel);
            await this.barService.BarCommentAsync(barCommentDTO);

            return Ok();
        }
        public async Task<IActionResult> Rating(BarRatingViewModel barRatingViewModel)
        {
            var barRatingDTO = this.barRatingMapper.MapFromViewModel(barRatingViewModel);
            await this.barService.BarRatingAsync(barRatingDTO);

            return Ok();
        }
    }
}