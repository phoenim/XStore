using XStore.Domain.Entities.Commons;
using XStore.Domain.Entities.Products;

namespace XStore.Domain.Entities.Carts
{
    public class CartItem : BaseEntity
    {
        public long Id { get; set; }
        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }

        public virtual Product Product { get; set; }
        public long ProductId { get; set; }

        public int count { get; set; }
    }
}
