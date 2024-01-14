namespace eBookStore.Application.DTOs.CartItem;

public class CartItemDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public int Qty { get; set; }
}
