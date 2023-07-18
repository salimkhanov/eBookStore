using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class PaymentMethod : BaseEntity
{
    public string Method { get; set; } = default!;
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
