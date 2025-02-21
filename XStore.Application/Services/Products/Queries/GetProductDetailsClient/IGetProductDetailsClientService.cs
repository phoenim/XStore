using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetProductDetailsClient
{
    public interface IGetProductDetailsClientService
    {
        Result<ProductDetailsForClientDto> Execute(long Id);
    }
}
