namespace eBookStore.Application.DTOs.ShoppingCartItem;

public class UpdateShoppingCartItemDTO
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int BookItemId { get; set; }
    public int Quantity { get; set; }
}
