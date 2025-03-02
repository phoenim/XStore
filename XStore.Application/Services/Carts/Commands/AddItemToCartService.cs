using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Carts;

namespace XStore.Application.Services.Carts.Commands
{
    public class AddItemToCartService : IAddItemToCartService
    {
        private readonly IDataBaseContext _context;

        public AddItemToCartService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(long productId, Guid browserId)
        { 
            var cart = _context.Carts.Where(c => c.BrowserId == browserId).FirstOrDefault();

            if (cart == null)
            {
                cart = new Cart
                {
                    BrowserId = browserId,

                };
                _context.Carts.Add(cart);
                _context.SaveChanges();
            }

            var product = _context.Products.Find(productId);

            var cartItem = _context.CartItems.Where(c => c.ProductId == productId && c.CartId == cart.Id).FirstOrDefault();

            if (cartItem == null)
            {
                CartItem newItem = new CartItem()
                {
                    count = 1,
                    CartId = cart.Id,
                    ProductId = productId,

                };
                _context.CartItems.Add(newItem);
                _context.SaveChanges();

            }
            else
            {
                cartItem.count++;
                _context.SaveChanges();
            }

            return new Result
            {
                IsSuccess = true,
                Message = "محصول با موفقیت به سبد خرید اضافه شد"
            };

        }
    }
}
