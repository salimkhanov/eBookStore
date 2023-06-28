using eBookStore.Domain.Enums;

namespace eBookStore.Application.DTOs.PaymentType;

public class GetPaymentTypeDTO
{
    public int Id { get; set; }
    public string Value { get; set; }
    public EntityStatus EntityStatus { get; set; }
}
