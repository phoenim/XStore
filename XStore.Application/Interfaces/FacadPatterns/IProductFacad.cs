﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Application.Services.Products.Commands.AddNewCategory;
using XStore.Application.Services.Products.Commands.AddNewProduct;
using XStore.Application.Services.Products.Queries.GetAllCategories;
using XStore.Application.Services.Products.Queries.GetCategories;
using XStore.Application.Services.Products.Queries.GetProductDetailsAdmin;
using XStore.Application.Services.Products.Queries.GetProductDetailsClient;
using XStore.Application.Services.Products.Queries.GetProductsForAdmin;
using XStore.Application.Services.Products.Queries.GetProductsForClient;

namespace XStore.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        GetCategoryService GetCategoryService { get; }
        AddNewProductService AddNewProductService { get; }
        GetAllCategoriesService GetAllCategoriesService { get; }
        GetProductsForAdminService GetProductsForAdminService { get; }
        GetProductDetailsAdminService GetProductDetailsAdminService { get; }
        GetProductsForClientService GetProductsForClientService { get; }
        GetProductDetailsClientService GetProductDetailsClientService { get; }
    }
}
