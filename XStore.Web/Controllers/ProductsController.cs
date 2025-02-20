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
        public IActionResult Index()
        {
            return View(_productFacad.GetProductsForClientService.Execute().Data);
        }
    }
}
