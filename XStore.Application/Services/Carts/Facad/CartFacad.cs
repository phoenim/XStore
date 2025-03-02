using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Interfaces.Context;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Application.Services.Carts.Commands.AddNewItemToCart;

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
    }
}
