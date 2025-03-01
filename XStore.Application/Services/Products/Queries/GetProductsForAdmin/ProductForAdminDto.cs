using Microsoft.AspNetCore.Http;

namespace XStore.Application.Services.Products.Queries.GetProductsForAdmin
{
    public class ProductForAdminDto
    {
        public long Id {  get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public string Brand { get; set; }
        public int Inventory {  get; set; }
        public double Price {  get; set; }
        public bool Displayed { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }

}
