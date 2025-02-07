using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Products.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    { 
        private readonly IDataBaseContext _context;

        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result Execute(long? parentId, string categoryName)
        {
            if(!String.IsNullOrWhiteSpace(categoryName))
            {
                Category category = new Category();
                category.Name = categoryName;
                category.ParentCategory = this.GetCategory(parentId);

                _context.Categories.Add(category);
                _context.SaveChanges();

                return new Result()
                { 
                    IsSuccess = true,
                    Message = "عملیات با موفقیت انجام شد."
                };
            }

            return new Result()
            {
                IsSuccess = false,
                Message = "لطفا نام دسته بندی را وارد کنید."
            };
        }

        private Category GetCategory(long? Id)
        {
            return _context.Categories.Find(Id);
        }

    
    }
}
