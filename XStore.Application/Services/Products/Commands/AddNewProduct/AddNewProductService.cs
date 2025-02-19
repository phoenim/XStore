using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Products.Commands.AddNewProduct
{
    public partial class AddNewProductService : IAddNewProductService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public AddNewProductService (IDataBaseContext context,
                                     IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public Result Execute (RequestAddProductDto request)
        {
            try
            {
                var category = _context.Categories.Find(request.CategoryId);

                Product newProduct = new Product()
                {
                    Name = request.Name,
                    Brand = request.Brand,
                    Displayed = request.Displayed,
                    Description = request.Describtion,
                    Price = request.Price,
                    Inventory = request.Inventory,
                    ProductCategory = category
                };
                _context.Products.Add(newProduct);


                if(request.Images != null)
                {
                    List<ProductImg> productImgs = new List<ProductImg>();
                    foreach (var item in request.Images)
                    {
                        var uploadedImage = UploadFile(item);
                        ProductImg newImg = new ProductImg()
                        {
                            Product = newProduct,
                            Src = uploadedImage.FileAddress,
                        };
                        productImgs.Add(newImg);
                    }
                    _context.ProductImgs.AddRange(productImgs);
                }

                List<ProductFeature> Productfeatures = new List<ProductFeature>();
                foreach (var item in request.Features)
                {
                    ProductFeature feature = new ProductFeature()
                    {
                        DisplayName = item.DisplayName,
                        Value = item.Value,
                        Product = newProduct,
                    };
                    Productfeatures.Add(feature);
                }
                _context.ProductFeatures.AddRange(Productfeatures);

                _context.SaveChanges();

                return new Result()
                {
                    IsSuccess = true,
                    Message = "محصول با موفقیت افزوده شد"
                };
            }
            catch (Exception ex)
            {
                return new Result()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }


        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

}

