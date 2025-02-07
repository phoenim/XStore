using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XStore.Domain.Entities.Products
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }

        public ICollection<Category> ChildCategories { get; set; }
    }
}
