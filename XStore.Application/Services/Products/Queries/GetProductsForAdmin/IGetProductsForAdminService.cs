using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetProductsForAdmin
{
    public interface IGetProductsForAdminService
    {
        Result<List<ProductForAdminDto>> Execute();

    }

}
