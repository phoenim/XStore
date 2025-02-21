using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XStore.Application.Services.Products.Queries.GetProdctDetailClient
{
    public interface IGetProductDetailClient
    {
    }

    public class ProductDetailClientDto
    {
        public string title { get; set; }
    }
}
