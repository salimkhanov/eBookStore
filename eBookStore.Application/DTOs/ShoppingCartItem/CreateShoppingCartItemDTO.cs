namespace eBookStore.Application.DTOs.ShoppingCartItem
{
    public class CreateShoppingCartItemDTO
    {
        public int CartId { get; set; }
        public int BookItemId { get; set; }
        public int Quantity { get; set; }
    }
}
