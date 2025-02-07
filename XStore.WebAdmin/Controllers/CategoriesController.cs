using Microsoft.AspNetCore.Mvc;
using XStore.Application.Interfaces.FacadPatterns;

namespace XStore.WebAdmin.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly IProductFacad _productFacad;

        public CategoriesController (IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        [HttpGet]
        public IActionResult AddNewCategory (long? Id)
        {
            ViewBag.ParentId = Id;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewCategory (long? parentId, string name)
        {
            var result = _productFacad.AddNewCategoryService.Execute (parentId, name);
            return Json(result);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
