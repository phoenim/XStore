using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Interfaces.Context;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Application.Services.Menus.Queries.GetCategoriesForMenuService;

namespace XStore.Application.Services.Menus.Facad
{
    public class MenuFacad : IMenuFacad
    {
        private readonly IDataBaseContext _context;

        public MenuFacad (IDataBaseContext context)
        {
            _context = context;
        }

        private IGetCategoriesForMenuService _getCategoriesForMenuService;
        public IGetCategoriesForMenuService GetCategoriesForMenuService
        {
            get
            {
                return _getCategoriesForMenuService = _getCategoriesForMenuService ?? new GetCategoriesForMenuService(_context);
            }
        }
    }
}
