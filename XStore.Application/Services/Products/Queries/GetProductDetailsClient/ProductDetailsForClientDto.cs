namespace XStore.Application.Services.Products.Queries.GetProductDetailsClient
{
    public class ProductDetailsForClientDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public List<string> ImgesSrc { get; set; }
        public List<ProductDetailsForClient_FeatureDto> Features { get; set; }
        
    }
}
