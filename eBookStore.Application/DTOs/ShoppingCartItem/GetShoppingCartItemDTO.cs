using eBookStore.Domain.Enums;

namespace eBookStore.Application.DTOs.ShoppingCartItem;

public class GetShoppingCartItemDTO
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int BookItemId { get; set; }
    public int Quantity { get; set; }
    public EntityStatus EntityStatus { get; set; }
}
