namespace XStore.Application.Services.Products.Queries.GetProductDetailsAdmin
{
    public class ProductDetailsAdminDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public bool Displayed { get; set; }
        public int Inventory {  get; set; }
        public double Price { get;set; }
        public List<ProductDetail_FetureDto> Features { get; set; }
    }
}
