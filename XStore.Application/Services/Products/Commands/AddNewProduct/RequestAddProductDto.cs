using Microsoft.AspNetCore.Http;

namespace XStore.Application.Services.Products.Commands.AddNewProduct
{
    public class RequestAddProductDto
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Describtion { get; set; }
        public double Price { get; set; }
        public int Inventory { get; set; }
        public long CategoryId { get; set; }
        public bool Displayed { get; set; }
        public List<AddNewProduct_FeatureDto> Features { get; set; }
        public List<IFormFile> Images { get; set; }
        
    }
}
