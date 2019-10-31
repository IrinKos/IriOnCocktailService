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

        public BarController(IBarService barService,IDTOMapper<CreateBarViewModel,BarDTO> barDTOMapper)
        {
            this.barService = barService;
            this.barDTOMapper = barDTOMapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBarViewModel viewModel)
        {
            var barDTO = this.barDTOMapper.MapFrom(viewModel);

            await this.barService.CreateBar(barDTO);

            return Ok(barDTO);
        }
    }
}