using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;
using XStore.Domain.Entities.Products;

namespace XStore.Application.Services.Menus.Queries.GetCategoriesForMenuService
{
    public class GetCategoriesForMenuService : IGetCategoriesForMenuService
    {
        private readonly IDataBaseContext _context;

        public GetCategoriesForMenuService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<Category>> Execute()
        {
            var categories = _context.Categories.Where(c => c.ParentCategoryId == null)
                             .Include(c => c.ChildCategories)
                             .ToList();

            return new Result<List<Category>>
            {
                Data = categories,
                IsSuccess = true,
                Message ="دسته بندی ها با موفقیت دریافت شدند."
            };
        }
    }

}
