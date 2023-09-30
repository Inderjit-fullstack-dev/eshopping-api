namespace Basket.Core.Entities
{
    public class ShoppingCartItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
