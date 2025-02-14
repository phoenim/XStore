namespace XStore.Application.Services.Products.Commands.AddNewProduct
{
    public partial class AddNewProductService
    {
        public class UploadDto
        {
            public long Id { get; set; }
            public bool Status { get; set; }
            public string FileAddress { get; set; }
        }
    }
}
