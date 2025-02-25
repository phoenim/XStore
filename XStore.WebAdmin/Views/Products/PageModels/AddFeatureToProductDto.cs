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
}
