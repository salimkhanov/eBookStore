using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class ShippingMethod : BaseEntity
{
    public string Name { get; set; } = default!;
    public double Price { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
