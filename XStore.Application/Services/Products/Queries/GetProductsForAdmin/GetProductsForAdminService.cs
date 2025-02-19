using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Products.Queries.GetProductsForAdmin
{
    public class GetProductsForAdminService : IGetProductsForAdminService
    {
        private readonly IDataBaseContext _context;

        public GetProductsForAdminService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<ProductForAdminDto>> Execute ()
        {
            if (_context.Products.Count() == 0)
            {
                return new Result<List<ProductForAdminDto>> ()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "محصولی برای نمایش وجود ندارد"
                };
            }

            List<ProductForAdminDto> productList = new List<ProductForAdminDto>();

            var products = _context.Products
                            .Include(p => p.ProductCategory)
                            .ToList();

            foreach (var item in products)
            {
                productList.Add(
                    new ProductForAdminDto()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Brand = item.Brand,
                        Describtion = item.Description,
                        Price = item.Price,
                        Inventory = item.Inventory,
                        Category = CategoryStr(item.CategoryId),
                        Displayed = item.Displayed
                    });
               
            }

            return new Result<List<ProductForAdminDto>>()
            {
                Data = productList,
                IsSuccess = true,
                Message = "محصولات دریافت شدند"
            };
        }

        private string CategoryStr (long Id)
        {
            Category category = _context.Categories.Find(Id);

            string res = category.ParentCategoryId == 0 ?
                         $"{category.Name}" : $"{_context.Categories.Find(category.ParentCategoryId).Name} - {category.Name}";
            return res;
        }
    }

}
