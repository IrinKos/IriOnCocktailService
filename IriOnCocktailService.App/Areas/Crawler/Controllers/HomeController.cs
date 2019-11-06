using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Crawler.Controllers
{
    [Area("Crawler")]
    [Authorize(Roles = "BarCrawler")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}