﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using IriOnCocktailService.App.Infrasturcture.Mappers.Contracts;
using IriOnCocktailService.App.Models;
using IriOnCocktailService.ServiceLayer.DTOS;
using IriOnCocktailService.ServiceLayer.Services;
using IriOnCocktailService.ServiceLayer.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    [Area("Magician")]
    [Authorize(Roles = "CocktailMagician")]
    public class CocktailController : Controller
    {
        private readonly ICocktailService cocktailService;
        private readonly IBarService barService;
        private readonly IIngredientService ingredientService;
        private readonly IDTOMapper<CreateCocktailViewModel, CocktailDTO> createCocktailMapper;
        private readonly IViewModelMapper<CocktailDTO, CreateCocktailViewModel> createCocktailMapperToVM;
        private readonly IViewModelMapper<CocktailDTO, CocktailViewModel> cocktailViewModelMapper;
        private readonly IViewModelMapper<BarDTO, BarsForCocktailViewModel> barsForCocktailMapper;
        private readonly IViewModelMapper<CocktailDTO, DeleteCocktailViewModel> deleteCocktailMapper;
        private readonly IViewModelMapper<CommentDTO, CommentViewModel> commentMapper;
        private readonly IViewModelMapper<CocktailDTO, DisplayCocktailViewModel> displayCocktailMapper;
        private readonly IViewModelMapper<ICollection<CocktailDTO>, CollectionViewModel> collectionMapper;
        private readonly IViewModelMapper<IngredientDTO, CreateIngredientViewModel> ingredientMapper;

        public CocktailController(ICocktailService cocktailService,
                                  IBarService barService,
                                  IIngredientService ingredientService,
                                  IDTOMapper<CreateCocktailViewModel, CocktailDTO> createCocktailMapper,
                                  IViewModelMapper<CocktailDTO, DisplayCocktailViewModel> displayCocktailMapper,
                                  IViewModelMapper<CocktailDTO, CreateCocktailViewModel> createCocktailMapperToVM,
                                  IViewModelMapper<CocktailDTO, CocktailViewModel> cocktailViewModelMapper,
                                  IViewModelMapper<BarDTO, BarsForCocktailViewModel> barsForCocktailMapper,
                                  IViewModelMapper<CocktailDTO, DeleteCocktailViewModel> deleteCocktailMapper,
                                  IViewModelMapper<CommentDTO, CommentViewModel> commentMapper,
                                  IViewModelMapper<ICollection<CocktailDTO>, CollectionViewModel> collectionMapper,
                                  IViewModelMapper<IngredientDTO, CreateIngredientViewModel> ingredientMapper)
        {
            this.cocktailService = cocktailService;
            this.barService = barService;
            this.ingredientService = ingredientService;
            this.createCocktailMapper = createCocktailMapper;
            this.displayCocktailMapper = displayCocktailMapper;
            this.createCocktailMapperToVM = createCocktailMapperToVM;
            this.cocktailViewModelMapper = cocktailViewModelMapper;
            this.barsForCocktailMapper = barsForCocktailMapper;
            this.deleteCocktailMapper = deleteCocktailMapper;
            this.commentMapper = commentMapper;
            this.collectionMapper = collectionMapper;
            this.ingredientMapper = ingredientMapper;
        }
        public async Task<IActionResult> Index()
        {
            var cocktails = await this.cocktailService.GetAllCocktailsDTO();
            var cocktailsViewModel = collectionMapper.MapFromDTO(cocktails);
            ////new List<DisplayCocktailViewModel>();

            //foreach (var cocktailsVM in cocktails)
            //{
            //    cocktailsViewModel.Add(displayCocktailMapper.MapFromDTO(cocktailsVM));
            //}
            cocktailsViewModel.Cocktails = cocktailsViewModel.Cocktails.OrderByDescending(c => c.Rating).ToList();

            return View(cocktailsViewModel);
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

            return Ok();
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
        public async Task<IActionResult> Edit(string Id)
        {
            var barDTO = await this.cocktailService.GetCocktailDTO(Id);
            var barVM = this.createCocktailMapperToVM.MapFromDTO(barDTO);

            return View(barVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateCocktailViewModel viewModel)
        {
            var cocktailDTO = this.createCocktailMapper.MapFromViewModel(viewModel);
            await cocktailService.EditCocktailAsync(cocktailDTO);

            //TODO remove ok
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var cocktailDTO = await cocktailService.GetCocktailDTO(Id);
            var cocktailViewModel = this.deleteCocktailMapper.MapFromDTO(cocktailDTO);

            //TODO remove ok
            //return RedirectToAction("Index", "Bar");
            return View(cocktailViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCocktailViewModel viewModel)
        {
            //if (Id == null)
            //{
            //    return NotFound();
            //}

            //await this.cocktailService.DeleteCocktailAsync(Id);

            //TODO remove ok
            //return RedirectToAction("Index", "Bar");
            return Ok();
        }

        [HttpPost]
        public async Task<string> SetIngredientUnit(string id)
        {
            return await this.ingredientService.GetUnitType(id);
        }
        [HttpGet]
        public async Task<IActionResult> CocktailsToAdd()
        {
            var cocktailsDTO = await this.cocktailService.GetAllCocktailsDTO();
            var selectListOfCocktails = cocktailsDTO.Select(x => new SelectListItem(x.Name, x.Id));

            return Json(selectListOfCocktails);
        }
    }
}