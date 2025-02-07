using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Commands.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        Result Execute(long? parentId, string categoryName);
    }
}
