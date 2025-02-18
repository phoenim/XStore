namespace XStore.WebAdmin.Views.Product.PageModels
{
    using XStore.Application.Services.Products.Commands.AddNewProduct;
    using XStore.Domain.Entities.Products;
    public class AddFeatureToProductDto
    {
        public ProductBag Product { get; set; }
        public AddNewProduct_FeatureDto[] features { get; set; }
        public int reqFeatures { get; set; }

    }

    public class ProductBag
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public long CategoryId { get; set; }
        public bool Displayed { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
    }
}
