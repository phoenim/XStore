using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XStore.Domain.Entities.Products.PageDto
{
    public  class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        
    }
}
