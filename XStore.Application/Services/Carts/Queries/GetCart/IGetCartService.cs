using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Carts.Commands.GetCart
{
    public interface IGetCartService
    {
        Result<CartDto> Execute(Guid browserId);
    }
}
