using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Carts.Commands
{
    public interface IAddItemToCartService
    {
        Result Execute(long productId, Guid browserId);
    }
}
