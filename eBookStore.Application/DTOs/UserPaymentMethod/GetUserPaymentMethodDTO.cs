using eBookStore.Domain.Enums;

namespace eBookStore.Application.DTOs.UserPaymentMethod;

public class GetUserPaymentMethodDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PaymentTypeId { get; set; }
    public string Provider { get; set; }
    public int AccountNumbet { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsDefault { get; set; }
    public EntityStatus EntityStatus { get; set; }
}
