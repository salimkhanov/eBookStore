using eBookStore.Domain.Enums;

namespace eBookStore.Application.DTOs.ShippingMethod;

public class GetShippingMethodDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public EntityStatus EntityStatus { get; set; }
}
