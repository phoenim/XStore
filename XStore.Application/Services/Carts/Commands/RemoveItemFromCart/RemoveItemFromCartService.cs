using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;

namespace XStore.Application.Services.Carts.Commands.RemoveItemFromCart
{
    public class RemoveItemFromCartService : IRemoveItemFromCartService
    {
        private readonly IDataBaseContext _context;

        public RemoveItemFromCartService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(long productId, Guid browserId, int decreasCount = 0)
        {
            var foundedCart = _context.Carts.Where(c => c.BrowserId == browserId)
                              .Include(c => c.Items)
                              .ThenInclude(i => i.Product)
                              .FirstOrDefault();
            if (foundedCart == null)
            {
                return new Result()
                {
                    IsSuccess = false,
                    Message = "سبد خریدی یافت نشد"
                };
            }

            var foundedItem = foundedCart.Items.Where(i => i.ProductId == productId).FirstOrDefault();

            if (decreasCount == 0)
            {
                
                if (foundedItem != null)
                {
                    _context.CartItems.Remove(foundedItem);
                    _context.SaveChanges();

                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "محصول با موفقیت حدف شد"
                    };
                }

                return new Result()
                {
                    IsSuccess = false,
                    Message = "محصول یافت نشد"
                };

            }

            else
            {
                if(foundedItem != null)
                {
                    foundedItem.count -= decreasCount;
                    _context.SaveChanges();

                    return new Result()
                    {
                        IsSuccess = true,
                        Message = "تعداد محصول در سبد خرید کاهش یافت"
                    };
                }

            }

            return new Result()
            {
                IsSuccess = false,
                Message = ""
            };
        }
    }
}
