using Microsoft.EntityFrameworkCore;
using XStore.Application.Interfaces.Context;
using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetCategories
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _context;

        public GetCategoryService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<CategoryDto>> Execute (long? parentId)
        {
            var categories = _context.Categories
                .Include(p => p.ParentCategory)
                .Include(p => p.ChildCategories)
                .Where(p => p.ParentCategoryId == parentId)
                .ToList()
                .Select(p => new CategoryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Parent = p.ParentCategory != null ? new ParentCategoryDto
                    {
                        Id = p.ParentCategory.Id,
                        Name = p.ParentCategory.Name,
                    } : null,
                    HasChild = p.ChildCategories.Count() > 0 ? true : false

                }).ToList();

            return new Result<List<CategoryDto>>
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست با موفقیت برگشت داده شد"
            };
        }
    }
}
