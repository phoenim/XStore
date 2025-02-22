using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Services.Menus.Queries.GetCategoriesForMenuService;

namespace XStore.Application.Interfaces.FacadPatterns
{
    public interface IMenuFacad
    {
        IGetCategoriesForMenuService GetCategoriesForMenuService { get;}
    }
}
