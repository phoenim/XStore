using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetProductDetailsClient
{
    public class GetProductDetailsClientService : IGetProductDetailsClientService
    {
        private readonly IDataBaseContext _context;

        public GetProductDetailsClientService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ProductDetailsForClientDto> Execute (long Id)
        {
            var foundedProduct = _context.Products.Include(p => p.ProductFeatures)
                                 .Include(p => p.ProductCategory)
                                 .ThenInclude(c => c.ParentCategory)
                                 .FirstOrDefault(p => p.Id == Id);

            if(foundedProduct == null)
            {
                return new Result<ProductDetailsForClientDto>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "محصولی یافت نشد"
                };
            }

            List<ProductDetailsForClient_FeatureDto> foundedFeatures = new List<ProductDetailsForClient_FeatureDto> ();
            foreach(var item in foundedProduct.ProductFeatures)
            {
                foundedFeatures.Add(new ProductDetailsForClient_FeatureDto()
                {
                    DisplayName = item.DisplayName,
                    value = item.Value,
                });
            }

            return new Result<ProductDetailsForClientDto>()
            {
                IsSuccess = true,
                Message = "محصول با موفقیت پیدا شد",
                Data = new ProductDetailsForClientDto()
                {
                    Id = foundedProduct.Id,
                    Name = foundedProduct.Name,
                    Description = foundedProduct.Description,
                    Brand = foundedProduct.Brand,
                    Category = $"{foundedProduct.ProductCategory.Name}-{foundedProduct.ProductCategory.ParentCategory.Name}",
                    Price = foundedProduct.Price,
                    Features = foundedFeatures
                }
            };
        }
    }
}
