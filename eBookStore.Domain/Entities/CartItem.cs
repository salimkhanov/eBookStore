using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class CartItem : BaseEntity
{
    public int CartId { get; set; }
    public Cart Cart { get; set; } = default!;
    public int BookId { get; set; }
    public Book Book { get; set; } = default!;
    public int Qty { get; set; }
}
