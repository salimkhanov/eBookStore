using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class PaymentMethod : BaseEntity
{
    public string Method { get; set; } = default!;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<UserPaymentMethod> UserPaymentMethods { get; set; } = new List<UserPaymentMethod>();
}
