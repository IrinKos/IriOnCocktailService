using IriOnCocktailService.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IriOnCocktailService.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("BarCrawler"))
                return Redirect("~/Crawler/Home/Index");

            else if (User.IsInRole("CocktailMagician"))
                return Redirect("~/Magician/Home/Index");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
