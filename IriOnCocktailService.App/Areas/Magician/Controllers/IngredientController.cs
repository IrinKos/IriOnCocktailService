using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Magician.Controllers
{
    public class IngredientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}