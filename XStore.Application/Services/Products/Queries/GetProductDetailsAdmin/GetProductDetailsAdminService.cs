using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Products.Queries.GetProductDetailsAdmin
{
    public class GetProductDetailsAdminService : IGetProductDetailsAdminService
    {
        private readonly IDataBaseContext _context;

        public GetProductDetailsAdminService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ProductDetailsAdminDto> Execute (long Id)
        {
            var foundedProduct = _context.Products.Include(p => p.ProductFeatures)
                                  .Include(p => p.ProductCategory)
                                  .FirstOrDefault(p => p.Id == Id);

            if(foundedProduct == null)
            {
                return new Result<ProductDetailsAdminDto>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "محصول یافت نشد"
                };
            }

            ProductDetailsAdminDto product = new ProductDetailsAdminDto()
            {
                Name = foundedProduct.Name,
                Description = foundedProduct.Description,
                Price = foundedProduct.Price,
                Displayed = foundedProduct.Displayed,
                Inventory = foundedProduct.Inventory,
                Category = CategoryStr(foundedProduct.CategoryId),
                Features = FeaturesStr(foundedProduct.Id)

            };

            return new Result<ProductDetailsAdminDto>()
            {
                Data = product,
                IsSuccess = true,
                Message = "جزئیات با موفقیت دریافت شد"
            };
                                   
        }

        private string CategoryStr(long Id)
        {
            Category category = _context.Categories.Find(Id);

            string res = category.ParentCategoryId == 0 ?
                         $"{category.Name}" : $"{_context.Categories.Find(category.ParentCategoryId).Name} - {category.Name}";
            return res;
        }

        private List<string> FeaturesStr (long Id)
        {
            var productFeatures = _context.ProductFeatures.Where(p =>  p.ProductId == Id)
                                    .ToList();

            List<string> result = new List<string>();
            foreach(var item in productFeatures)
            {
                result.Add($"{item.DisplayName} - {item.Value}");
            }

            return result;
        }
    }
}
