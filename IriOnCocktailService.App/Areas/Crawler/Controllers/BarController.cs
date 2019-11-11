﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Crawler.Models;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Crawler.Controllers
{
    [Area("Crawler")]
    public class BarController : Controller
    {
        private readonly IBarService barService;
        private readonly IViewModelMapper<ICollection<BarDTO>, CollectionViewModel> collectionMapper;
        //private readonly IViewModelMapper<CollectionDTO, CollectionViewModel> collectionMapper;
        private readonly IDTOMapper<CommentViewModel, CommentDTO> barCommentMapper;
        private readonly IDTOMapper<RatingViewModel, RatingDTO> barRatingMapper;

        public BarController(IBarService barService,
                             //IViewModelMapper<CollectionDTO, CollectionViewModel> collectionMapper,
                             IViewModelMapper<ICollection<BarDTO>, CollectionViewModel> collectionMapper,
                             IDTOMapper<CommentViewModel, CommentDTO> barCommentMapper,
                             IDTOMapper<RatingViewModel, RatingDTO> barRatingMapper)
        {
            this.barService = barService;
            this.collectionMapper = collectionMapper;
            this.barCommentMapper = barCommentMapper;
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
        public IActionResult Comment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel barCommentViewModel)
        {
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

            return Ok();
        }
    }
}