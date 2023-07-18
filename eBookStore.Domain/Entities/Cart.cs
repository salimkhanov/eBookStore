using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
