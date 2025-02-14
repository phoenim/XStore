using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Products.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;

        public AddNewProductService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute (RequestAddProductDto request)
        {
            var category = _context.Categories.Find(request.CategoryId);

            Product newProduct = new Product()
            {
                Name = request.Name,
                Brand = request.Brand,
                Displayed = request.Displayed,
                Description = request.Describtion,
                Price = request.Price,
                Inventory = request.Inventory,
                ProductCategory = category
            };
            _context.Products.Add(newProduct);

            List<ProductImg> productImgs = new List<ProductImg>();

            return null;
        }
    }
}
