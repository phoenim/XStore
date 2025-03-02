using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Services.Carts.Commands;

namespace XStore.Application.Interfaces.FacadPatterns
{
    public interface ICartFacad
    {
        IAddItemToCartService AddToCartService { get; }
    }
}
