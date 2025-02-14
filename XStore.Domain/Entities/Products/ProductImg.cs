namespace XStore.Domain.Entities.Products
{
    public class ProductImg
    {
        public long Id { get; set; }
        public string Src {  get; set; }

        public virtual Product Product {  get; set; }
        public long ProductId { get; set; }

    }
}
