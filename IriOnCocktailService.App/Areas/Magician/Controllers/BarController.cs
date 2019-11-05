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
        private readonly IViewModelMapper<CollectionDTO, CollectionViewModel> collectionMapper;
        //private readonly IViewModelMapper<BarDTO, DeleteBarViewModel> deleteBarViewModelMapper;

        public BarController(IBarService barService,
                             IDTOMapper<CreateBarViewModel,BarDTO> barDTOMapper,
                             IViewModelMapper<BarDTO, CreateBarViewModel> createBarViewModelMapper,
                             IViewModelMapper<CollectionDTO, CollectionViewModel> collectionMapper)
                            // IViewModelMapper<BarDTO,DeleteBarViewModel> deleteBarViewModelMapper,
        {
            this.barService = barService;
            this.barDTOMapper = barDTOMapper;
            this.createBarViewModelMapper = createBarViewModelMapper;
            this.collectionMapper = collectionMapper;
          //  this.deleteBarViewModelMapper = deleteBarViewModelMapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dto = await this.barService.GetBarsAsync();
            var viewModel = this.collectionMapper.MapFromDTO(dto);
            return View(viewModel);
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

            return Ok(barDTO);
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

            return Ok();
        }
    }
}