using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Menus.Queries.GetCategoriesForMenuService
{
    public interface IGetCategoriesForMenuService
    {
        Result<List<Category>> Execute();
    }

}
