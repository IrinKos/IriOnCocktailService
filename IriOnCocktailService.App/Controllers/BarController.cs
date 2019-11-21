﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.App.Models;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Controllers
{
    public class BarController : Controller
    {
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;
        private readonly IViewModelMapper<BarDTO, BarViewModel> barViewModelMapper;
        private readonly IViewModelMapper<CocktailDTO, CocktailViewModel> cocktailViewModelMapper;
        private readonly IViewModelMapper<CommentDTO, CommentViewModel> commentMapper;

        public BarController(IBarService barService, ICocktailService cocktailService,
                              IViewModelMapper<BarDTO, BarViewModel> barViewModelMapper,
                              IViewModelMapper<CocktailDTO, CocktailViewModel> cocktailViewModelMapper,
                              IViewModelMapper<CommentDTO, CommentViewModel> commentMapper)
        {
            this.barService = barService;
            this.cocktailService = cocktailService;
            this.barViewModelMapper = barViewModelMapper;
            this.cocktailViewModelMapper = cocktailViewModelMapper;
            this.commentMapper = commentMapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var barsDTO = await this.barService.GetBarsAsync();
            var barsViewModel = new List<BarViewModel>();
            foreach (var bar in barsDTO)
            {
                barsViewModel.Add(this.barViewModelMapper.MapFromDTO(bar));
            }
            barsViewModel = barsViewModel
                .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                .ToList();
            return View(barsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var barDTO = await this.barService.GetBarAsync(id);
            var barViewModel = this.barViewModelMapper.MapFromDTO(barDTO);
            var barCommentDTOs = await this.barService.GetAllCommentsForBar(id);

            barViewModel.Comments = barCommentDTOs.Select(c => this.commentMapper.MapFromDTO(c));

            return View(barViewModel);
        }
    }
}