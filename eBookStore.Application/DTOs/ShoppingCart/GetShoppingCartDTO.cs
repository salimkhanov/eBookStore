using eBookStore.Domain.Enums;

namespace eBookStore.Application.DTOs.ShoppingCart;

public class GetShoppingCartDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public EntityStatus EntityStatus { get; set; }
}
