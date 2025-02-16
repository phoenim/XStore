using Microsoft.AspNetCore.Mvc;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Domain.Entities.Products;

namespace XStore.WebAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductController (IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.categories = _productFacad.GetAllCategoriesService.Execute().Data;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(Product newProduct, int reqFeatures, List<IFormFile> imges)
        {
            return View();
        }
    }
}
