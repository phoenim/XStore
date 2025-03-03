using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;

namespace XStore.Application.Services.Carts.Commands.GetCart
{
    public class GetCartService : IGetCartService
    {
        private readonly IDataBaseContext _context;

        public GetCartService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<CartDto> Execute (Guid browserId)
        {
            var foundedCart = _context.Carts.Where(c =>  c.BrowserId == browserId)
                              .Include(c => c.Items)
                              .ThenInclude(i => i.Product)
                              .FirstOrDefault();

            if(foundedCart == null)
            {
                return new Result<CartDto>()
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "سبد خریدی پیدا نشد"
                };
            }    

            List<CartItemDto> cartItems = new List<CartItemDto>();
            foreach(var item in foundedCart.Items)
            {
                cartItems.Add(new CartItemDto()
                {
                    product = item.Product.Name,
                    count = item.count,
                    PriceForOne = item.PriceForOne,
                    PriceForCount = item.PriceForCount,
                    ProductId = item.ProductId,
                });
            }

            return new Result<CartDto>()
            {
                Data = new CartDto()
                {
                    Items = cartItems,
                    TotalPrice= foundedCart.TotalPrice,
                },
                IsSuccess = true,
                Message = "سبد خرید با موفقیت دریافت شد"
                
            };
        }
    }
}
