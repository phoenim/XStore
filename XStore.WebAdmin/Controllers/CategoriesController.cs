using Microsoft.AspNetCore.Mvc;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Domain.Entities.Products;

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
        public IActionResult AddNewCategory (Category newCat)
        {
            var result = _productFacad.AddNewCategoryService.Execute (newCat.ParentCategoryId, newCat.Name);
            return Json(result);
        }


        public IActionResult Index(long? parentId)
        {
            return View(_productFacad.GetCategoryService.Execute(parentId).Data);
        }
    }
}
