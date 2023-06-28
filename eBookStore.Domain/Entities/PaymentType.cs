using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class PaymentType:BaseEntity
{
    public string Value { get; set; }

    public ICollection<UserPaymentMethod> UserPaymentMethod { get; set; }
}
