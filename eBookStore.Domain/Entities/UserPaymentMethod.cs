using eBookStore.Domain.Entities.Base;

namespace eBookStore.Domain.Entities;

public class UserPaymentMethod:BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int PaymentTypeId { get; set; }
    public PaymentType PaymentType { get; set; }
    public string Provider { get; set; }
    public int AccountNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsDefault { get; set; }
}
