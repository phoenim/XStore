using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Commands.AddNewProduct
{
    public interface IAddNewProductService
    {
        Result Execute(RequestAddProductDto request);
    }
}
