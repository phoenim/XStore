using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Carts.Commands.RemoveItemFromCart
{
    public interface IRemoveItemFromCartService
    {
        Result Execute(long ProductId, Guid browserId, int decreasCount = 0);
    }
}
