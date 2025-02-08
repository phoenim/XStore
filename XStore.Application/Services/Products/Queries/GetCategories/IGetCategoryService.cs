using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetCategories
{
    public interface IGetCategoryService
    {
        Result<List<CategoryDto>> Execute(long? parentId);
    }
}
