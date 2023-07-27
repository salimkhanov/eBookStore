using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class ShippingMethod:BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }

    public ICollection<ShopOrder> ShopOrders { get; set; }
}
