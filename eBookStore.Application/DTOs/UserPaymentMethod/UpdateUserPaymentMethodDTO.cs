namespace eBookStore.Application.DTOs.UserPaymentMethod;

public class UpdateUserPaymentMethodDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PaymentTypeId { get; set; }
    public string Provider { get; set; }
    public int AccountNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsDefault { get; set; }
}
