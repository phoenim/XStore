using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetProductsForClient
{
    public  interface IGetProductsForClientService
    {
        Result<List<ProductForClientDto>> Execute(long? categoryId);
    }
}
