using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Interfaces.Context;
using XStore.Application.Interfaces.FacadPatterns;
using XStore.Application.Services.Products.Commands.AddNewCategory;
using XStore.Application.Services.Products.Commands.AddNewProduct;
using XStore.Application.Services.Products.Queries.GetAllCategories;
using XStore.Application.Services.Products.Queries.GetCategories;
using XStore.Application.Services.Products.Queries.GetProductDetailsAdmin;
using XStore.Application.Services.Products.Queries.GetProductsForAdmin;

namespace XStore.Application.Services.Products.Facad
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public ProductFacad(IDataBaseContext context,
                            IHostingEnvironment environment)
        { 
            _context = context;
            _environment = environment;
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

        private AddNewProductService _AddNewProduct;
        public AddNewProductService AddNewProductService
        {
            get
            {
                return _AddNewProduct = _AddNewProduct ?? new AddNewProductService(_context, _environment);
            }
        }

        private GetAllCategoriesService _GetAllCategories;
        public GetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _GetAllCategories = _GetAllCategories ?? new GetAllCategoriesService(_context);
            }
        }

        private GetProductsForAdminService _GetProductsForAdmin;
        public GetProductsForAdminService GetProductsForAdminService
        {
            get
            {
                return _GetProductsForAdmin = _GetProductsForAdmin ?? new GetProductsForAdminService(_context);
            }
        }

        private GetProductDetailsAdminService _GetProductDetailsAdmin;
        public GetProductDetailsAdminService GetProductDetailsAdminService
        {
            get
            {
                return _GetProductDetailsAdmin = _GetProductDetailsAdmin ?? new GetProductDetailsAdminService(_context);
            }
        }
    }
}
