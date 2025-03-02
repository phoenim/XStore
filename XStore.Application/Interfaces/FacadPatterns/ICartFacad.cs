using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Services.Carts.Commands.AddNewItemToCart;

namespace XStore.Application.Interfaces.FacadPatterns
{
    public interface ICartFacad
    {
        IAddItemToCartService AddToCartService { get; }
    }
}
