using eBookStore.Domain.Enums;

namespace eBookStore.Application.DTOs.OrderStatus;

public class GetOrderStatusDTO
{
    public int Id { get; set; }
    public string Status { get; set; }
    public EntityStatus EntityStatus { get; set; }
}
