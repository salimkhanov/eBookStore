using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
