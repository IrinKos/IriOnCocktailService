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
    public class BarController : Controller
    {
        private readonly IBarService barService;
        private readonly IDTOMapper<CreateBarViewModel, BarDTO> barDTOMapper;
        private readonly IViewModelMapper<BarDTO, CreateBarViewModel> createBarViewModelMapper;
        private readonly IViewModelMapper<BarDTO, DisplayBarsViewModel> barViewModelMapper;
        private readonly IViewModelMapper<ICollection<BarDTO>, CollectionViewModel> collectionMapper;
        //private readonly IViewModelMapper<BarDTO, DeleteBarViewModel> deleteBarViewModelMapper;

        public BarController(IBarService barService,
                             IDTOMapper<CreateBarViewModel,BarDTO> barDTOMapper,
                             IViewModelMapper<BarDTO, CreateBarViewModel> createBarViewModelMapper,
                             IViewModelMapper<BarDTO, DisplayBarsViewModel> barViewModelMapper,
                             IViewModelMapper<ICollection<BarDTO>, CollectionViewModel> collectionMapper)
                            // IViewModelMapper<BarDTO,DeleteBarViewModel> deleteBarViewModelMapper,
        {
            this.barService = barService;
            this.barDTOMapper = barDTOMapper;
            this.createBarViewModelMapper = createBarViewModelMapper;
            this.barViewModelMapper = barViewModelMapper;
            this.collectionMapper = collectionMapper;
          //  this.deleteBarViewModelMapper = deleteBarViewModelMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var barsDto = await this.barService.GetBarsAsync();
            var viewModel = this.collectionMapper.MapFromDTO(barsDto);

            var barsViewModel = new List<DisplayBarsViewModel>();
            foreach (var bar in barsDto)
            {
                barsViewModel.Add(barViewModelMapper.MapFromDTO(bar));
            }
            //return View(viewModel);
            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            var barDTO = await this.barService.GetBarAsync(Id);
            var barViewModel = this.barViewModelMapper.MapFromDTO(barDTO);

            return View(barViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBarViewModel viewModel)
        {
            var barDTO = this.barDTOMapper.MapFromViewModel(viewModel);

            await this.barService.CreateBarAsync(barDTO);

            //TODO remove ok
            //return Ok(barDTO);
            return RedirectToAction("Index", "Bar");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            if(Id==null)
            {
                return NotFound();
            }

            await this.barService.DeleteBarAsync(Id);

            //TODO remove ok
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var barDTO = await this.barService.GetBarAsync(Id);
            var barVM = this.createBarViewModelMapper.MapFromDTO(barDTO);

            return View(barVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CreateBarViewModel viewModel)
        {
            var barDTO = this.barDTOMapper.MapFromViewModel(viewModel);
            await barService.EditBarAsync(barDTO);

            //TODO remove ok
            return Ok();
        }
    }
}