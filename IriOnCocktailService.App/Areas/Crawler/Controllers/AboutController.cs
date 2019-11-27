using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IriOnCocktailService.App.Areas.Crawler.Controllers
{
    public class AboutController : Controller
    {
        [Area("Crawler")]
        [Authorize(Roles = "BarCrawler")]
        public IActionResult Index()
        {
            return View();
        }
    }
}