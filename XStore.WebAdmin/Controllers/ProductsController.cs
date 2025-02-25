using Microsoft.AspNetCore.Mvc;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Application.Services.Products.Commands.AddNewProduct;
using XStore.Domain.Entities.Products;
using XStore.WebAdmin.Views.Product.PageModels;

namespace XStore.WebAdmin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductFacad _productFacad;
        private List<IFormFile> images = new List<IFormFile>();

        public ProductsController (IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index()
        {
            ProductListForAdmin products = new ProductListForAdmin()
            {
                products = _productFacad.GetProductsForAdminService.Execute().Data
            };
            return View(products);
        }

        public IActionResult Details (long Id)
        {
            return View(_productFacad.GetProductDetailsAdminService.Execute(Id).Data);
        }

        [HttpGet]
        public IActionResult AddNewProduct()
        {
            ViewBag.categories = _productFacad.GetAllCategoriesService.Execute().Data;
            return View();
        }

        [HttpPost]
        public IActionResult AddNewProduct(ProductBag newProduct, List<IFormFile> images)
        {
            RequestAddProductDto request = new RequestAddProductDto()
            {
                Name = newProduct.Name,
                Brand = newProduct.Brand,
                Price = newProduct.Price,
                Describtion = newProduct.Description,
                Inventory = newProduct.Inventory,
                Displayed = newProduct.Displayed,
                CategoryId = newProduct.CategoryId,
                Features = newProduct.features.ToList(),
                Images = newProduct.images,
            };
            

            return Json(_productFacad.AddNewProductService.Execute(request));
        }

      
        public IActionResult AddFeatureToProduct(ProductBag newProduct, int reqFeatures, IFormFile images)
        {
            
            AddFeatureToProductDto product = new AddFeatureToProductDto();
            product.Product = newProduct;
            product.reqFeatures = reqFeatures;
            product.features = new AddNewProduct_FeatureDto[reqFeatures];

            return View(product);
        }
    }
}
