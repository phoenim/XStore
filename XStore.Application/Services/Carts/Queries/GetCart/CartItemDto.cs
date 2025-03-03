namespace XStore.Application.Services.Carts.Commands.GetCart
{
    public class CartItemDto
    {
        public long ProductId { get; set; }
        public string product {  get; set; }
        public int count { get; set; }

        public double PriceForOne { get; set; }
        public double PriceForCount { get; set; }
    }
}
