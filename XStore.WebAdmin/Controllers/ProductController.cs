using Microsoft.AspNetCore.Mvc;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Application.Services.Products.Commands.AddNewProduct;
using XStore.Domain.Entities.Products;
using XStore.WebAdmin.Views.Product.PageModels;

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
        public IActionResult AddNewProduct(AddFeatureToProductDto newProduct)
        {
            RequestAddProductDto request = new RequestAddProductDto()
            {
                Name = newProduct.Product.Name,
                Brand = newProduct.Product.Brand,
                Price = newProduct.Product.Price,
                Describtion = newProduct.Product.Description,
                Inventory = newProduct.Product.Inventory,
                Displayed = newProduct.Product.Displayed,
                CategoryId = newProduct.Product.CategoryId,
                Features = newProduct.features.ToList(),
            };
            

            return Json(_productFacad.AddNewProductService.Execute(request));
        }

        [HttpGet]
        public IActionResult AddFeatureToProduct(ProductBag newProduct, int reqFeatures)
        {
            AddFeatureToProductDto product = new AddFeatureToProductDto();
            product.Product = newProduct;
            product.reqFeatures = reqFeatures;
            product.features = new AddNewProduct_FeatureDto[reqFeatures];

            return View(product);
        }
    }
}
