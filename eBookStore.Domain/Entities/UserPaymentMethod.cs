using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class UserPaymentMethod : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public PaymentMethod PaymentMethod { get; set; } = default!;
    public int PaymentMethodId { get; set; }
    public bool IsDefault { get; set; } 
}
