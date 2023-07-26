using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class OrderLine : BaseEntity
{
    public int BookId { get; set; }
    public int OrderId { get; set; }
    public int Qty { get; set; }
    public double Price { get; set; }
}
