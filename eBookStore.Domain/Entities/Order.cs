using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public int PaymentMethodId { get; set; }
    public int AddressId { get; set; }  
    public int ShippingMethodId { get; set; } = default!;
    public double OrderTotal { get; set; }
    public int OrderStatusId { get; set; }
    

    #region Navigation Property
    public virtual User User { get; set; } = default!;
    public virtual PaymentMethod PaymentMethod { get; set; } = default!;
    public virtual Address Address { get; set; } = default!;
    public virtual ShippingMethod ShippingMethod { get; set; } = default!;
    public virtual OrderStatus OrderStatus { get; set; } = default!;
    public virtual ICollection<UserReview> UserReviews { get; set; } = new List<UserReview>();
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    #endregion
}
