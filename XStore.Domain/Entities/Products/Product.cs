using XStore.Domain.Entities.Commons;

namespace XStore.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Inventory {  get; set; }
        public bool Displayed {  get; set; }
        
        public virtual Category ProductCategory {  get; set; }
        public long CategoryId { get; set; }

        public ICollection<ProductImg> ProductImgs {  get; set; }
        public ICollection<ProductFeature> ProductFeatures { get; set; }
    }
}
