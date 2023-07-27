using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class ShopOrder:BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime OrderDate { get; set; }
    public int UserPaymentMethodId { get; set; }
    public  UserPaymentMethod UserPaymentMethod { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public int ShippingMethodId { get; set; }
    public ShippingMethod ShippingMethod { get; set; }
    public int OrderTotal { get; set; }
    public int OrderStatusId { get; set; }
    public OrderStatus OrderStatus { get; set; }
}
