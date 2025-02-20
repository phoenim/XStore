using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetProductsForClient
{
    public class GetProductsForClientService : IGetProductsForClientService
    {
        private readonly IDataBaseContext _context;

        public GetProductsForClientService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<ProductForClientDto>> Execute()
        {
            if(_context.Products.Count() == 0)
            {
                return new Result<List<ProductForClientDto>>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "محصولی موجود نمیباشد"
                };
            }

            var foundedProducts = _context.Products.ToList();
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
}
