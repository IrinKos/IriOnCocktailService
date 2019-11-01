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
        private readonly IViewModelMapper<BarDTO, DeleteBarViewModel> deleteBarViewModelMapper;

        public BarController(IBarService barService,
                             //IViewModelMapper<BarDTO,DeleteBarViewModel> deleteBarViewModelMapper,
                             IDTOMapper<CreateBarViewModel,BarDTO> barDTOMapper)
        {
            this.barService = barService;
            this.barDTOMapper = barDTOMapper;
            this.deleteBarViewModelMapper = deleteBarViewModelMapper;
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
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var book = await _context.Books
        //        .Include(b => b.Status)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(book);
        //}
        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            if(Id==null)
            {
                return NotFound();
            }
            var barDTO = await this.barService.GetBar(Id);
           // var barViewModel = barDTOMapper.MapFrom();
            return Ok();
        }
    }
}