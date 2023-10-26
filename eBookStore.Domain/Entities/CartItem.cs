using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class CartItem : BaseEntity
{
    public int CartId { get; set; }
    public int BookId { get; set; }
    public virtual Book Book { get; set; } = default!;
    public int Qty { get; set; }
    public double Price { get; set; }

}
