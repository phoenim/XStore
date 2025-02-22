using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Web.Models;

namespace XStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMenuFacad _MenuFacad;

        public HomeController(ILogger<HomeController> logger,
                              IMenuFacad menuFacad)
        {
            _logger = logger;
            _MenuFacad = menuFacad;
        }

        public IActionResult Index()
        {
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

        public IActionResult test ()
        {
            ViewBag.categories = _MenuFacad.GetCategoriesForMenuService.Execute();
            return View();
        }
    }
}
