using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public int PaymentMethodId { get; set; }
    public int AddressId { get; set; }  
    public int ShippingMethodId { get; set; } = default!;
    public double OrderTotal { get; set; }
    public int OrderStatusId { get; set; }
    

    #region Navigation Property
    public User User { get; set; } = default!;
    public PaymentMethod PaymentMethod { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public ShippingMethod ShippingMethod { get; set; } = default!;
    public OrderStatus OrderStatus { get; set; } = default!;
    public ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    #endregion
}
