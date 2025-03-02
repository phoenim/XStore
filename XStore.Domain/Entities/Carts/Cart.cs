using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XStore.Domain.Entities.Commons;
using XStore.Domain.Entities.Users;

namespace XStore.Domain.Entities.Carts
{
    public class Cart : BaseEntity
    {
        public long Id { get; set; }
        public Guid BrowserId { get; set; }
        
        public virtual User User { get; set; }
        public long UserId { get; set; }

        public bool IsFinished { get; set; }
        public ICollection<CartItem> Items { get; set; }
        
    }
}
