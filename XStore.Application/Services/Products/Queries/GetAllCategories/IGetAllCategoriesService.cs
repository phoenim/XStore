using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        Result<List<AllCategoriesDto>> Execute();
    }
}
