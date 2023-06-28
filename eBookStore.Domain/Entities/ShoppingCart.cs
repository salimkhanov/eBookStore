using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class ShoppingCart:BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public ICollection<ShoppingCartItem> ShoppingCartItem { get; set; }
}
