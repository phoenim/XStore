using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Interfaces.Context;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Application.Services.Products.Commands.AddNewCategory;
using XStore.Application.Services.Products.Queries.GetCategories;

namespace XStore.Application.Services.Products.Facad
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _context;

        public ProductFacad(IDataBaseContext context)
        { 
            _context = context;
        }

        private AddNewCategoryService _AddNewCategory;
        public AddNewCategoryService AddNewCategoryService
        { 
            get 
            { 
                return _AddNewCategory = _AddNewCategory ?? new AddNewCategoryService(_context); 
            }
        }

        private GetCategoryService _GetCategory;
        public GetCategoryService GetCategoryService
        {
            get
            {
                return _GetCategory = _GetCategory ?? new GetCategoryService(_context);
            }
        }
    }
}
