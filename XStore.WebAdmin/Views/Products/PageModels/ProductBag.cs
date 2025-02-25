using XStore.Application.Services.Products.Commands.AddNewProduct;
using XStore.Domain.Entities.Products;

namespace XStore.WebAdmin.Views.Product.PageModels
{
    public class ProductBag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public long CategoryId { get; set; }
        public bool Displayed { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public List<IFormFile> images { get; set; }
        public AddNewProduct_FeatureDto[] features { get; set; } = new AddNewProduct_FeatureDto[10];
    }
}
