using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IriOnCocktailService.App.Areas.Magician.Models;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    public class ErrorHandlerController : Controller
    {
        public IActionResult Index(MagicianErrorViewModel vm)
        {
            return View(vm);
        }
    }
}