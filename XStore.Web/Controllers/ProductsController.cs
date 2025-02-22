using Microsoft.AspNetCore.Mvc;
using XStore.Application.Interfaces.FacadPatterns;

namespace XStore.WebClient.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;

        public ProductsController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }
        public IActionResult Index(long? catId)
        {
            return View(_productFacad.GetProductsForClientService.Execute(catId).Data);
        }

        public IActionResult Details(long Id)
        {
            return View(_productFacad.GetProductDetailsClientService.Execute(Id).Data);
        }
    }
}
