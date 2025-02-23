using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Products.Queries.GetProductsForClient
{
    public class GetProductsForClientService : IGetProductsForClientService
    {
        private readonly IDataBaseContext _context;

        public GetProductsForClientService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<ProductForClientDto>> Execute(long? categoryId, string? searchKey)
        {
            List<Product> foundedProducts;
            if (categoryId == null)
            {
                if (!String.IsNullOrWhiteSpace(searchKey))
                {
                    foundedProducts = _context.Products.Where(p => p.Name.Contains(searchKey)).ToList();
                }

                else
                {
                    if (_context.Products.Count() == 0)
                    {
                        return new Result<List<ProductForClientDto>>()
                        {
                            Data = null,
                            IsSuccess = false,
                            Message = "محصولی موجود نمیباشد"
                        };
                    }

                    foundedProducts = _context.Products.ToList();
                    List<ProductForClientDto> products = new List<ProductForClientDto>();

                    foreach (var item in foundedProducts)
                    {
                        products.Add(new ProductForClientDto
                        {
                            Id = item.Id,
                            Title = item.Name,
                            Price = item.Price,
                            ImgSrc = ""
                        });
                    }

                    return new Result<List<ProductForClientDto>>()
                    {
                        Data = products,
                        IsSuccess = true,
                        Message = "محصولات دریافت شدند"
                    };
                }
               
            }

            
            
            else
            {
                if (_context.Categories.Where(c => c.Id == categoryId)
                .FirstOrDefault().ParentCategoryId == null)
                {
                    foundedProducts = _context.Products.Include(p => p.ProductCategory)
                    .ThenInclude(p => p.ChildCategories)
                    .Where(p => p.ProductCategory.ParentCategoryId == categoryId)
                    .Include(p => p.ProductFeatures)
                    .ToList();
                }

                else
                {
                    foundedProducts = _context.Products.Where(p => p.CategoryId == categoryId)
                                .Include(p => p.ProductCategory)
                                .ThenInclude(p => p.ChildCategories)
                                .Include(p => p.ProductFeatures)
                                .ToList();
                }
            }

            if(foundedProducts.Count > 0)
            {
                List<ProductForClientDto> products = new List<ProductForClientDto>();
                foreach (var item in foundedProducts)
                {
                    products.Add(new ProductForClientDto
                    {
                        Id = item.Id,
                        Title = item.Name,
                        Price = item.Price,
                    });

                }

                return new Result<List<ProductForClientDto>>()
                {
                    Data = products,
                    IsSuccess = true,
                    Message = "محصولات با موفقیت پیدا شدند"
                };
            }

            return new Result<List<ProductForClientDto>>()
            {
                Data = null,
                IsSuccess = false,
                Message = "محصولی یافت نشد"
            };
        }
    }
}
