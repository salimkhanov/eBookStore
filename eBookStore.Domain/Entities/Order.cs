using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public int PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public int AddressId { get; set; }  
    public ShippingMethod ShippingMethod { get; set; } = default!;
    public int ShippingMethodId { get; set; } = default!;
    public double OrderTotal { get; set; }
    public OrderStatus OrderStatus { get; set; } = default!;
    public int OrderStatusId { get; set; }
    public ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
