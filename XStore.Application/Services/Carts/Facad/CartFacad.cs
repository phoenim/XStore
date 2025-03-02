using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Interfaces.Context;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Application.Services.Carts.Commands.AddNewItemToCart;
using XStore.Application.Services.Carts.Commands.GetCart;
using XStore.Application.Services.Carts.Commands.RemoveItemFromCart;

namespace XStore.Application.Services.Carts.Facad
{
    public class CartFacad : ICartFacad
    {
        private readonly IDataBaseContext _context;
        
        public CartFacad (IDataBaseContext context)
        {
            _context = context;
        }

        private IAddItemToCartService _addItemToCart;
        public IAddItemToCartService AddToCartService
        {
            get
            {
                return _addItemToCart = _addItemToCart?? new AddItemToCartService(_context);
            }
        }

        private IGetCartService _getCart;
        public IGetCartService GetCartService
        {
            get
            {
                return _getCart = _getCart ?? new GetCartService(_context);
            }
        }

        private IRemoveItemFromCartService _removeFromCart;
        public IRemoveItemFromCartService RemoveFromCartService
        {
            get
            {
                return _removeFromCart = _removeFromCart ?? new RemoveItemFromCartService(_context);
            }
        }
    }
}
