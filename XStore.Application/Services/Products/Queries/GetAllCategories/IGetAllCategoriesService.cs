using XStore.Common.Dto;

namespace XStore.Application.Services.Products.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        Result<List<AllCategoriesDto>> Execute();
    }

    public class AllCategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
