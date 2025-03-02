using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Services.Carts.Commands.AddNewItemToCart;
using XStore.Application.Services.Carts.Commands.GetCart;
using XStore.Application.Services.Carts.Commands.RemoveItemFromCart;

namespace XStore.Application.Interfaces.FacadPatterns
{
    public interface ICartFacad
    {
        IAddItemToCartService AddToCartService { get; }
        IGetCartService GetCartService { get; }
        IRemoveItemFromCartService RemoveFromCartService { get; }
    }
}
