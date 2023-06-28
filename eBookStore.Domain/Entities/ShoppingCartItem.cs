using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class ShoppingCartItem:BaseEntity
{
    public int CartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int BookItemId { get; set; }
    public int Quantity { get; set; }
}
