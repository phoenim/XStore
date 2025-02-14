namespace XStore.Domain.Entities.Products
{
    public class ProductFeature
    {
        public long Id { get; set; }
        public string DisplayName {  get; set; }
        public string Value { get; set; }

        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
    }
}
