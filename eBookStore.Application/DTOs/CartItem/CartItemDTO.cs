namespace eBookStore.Application.DTOs.CartItem;

public record CartItemDTO(
    int Id,
    int UserId,
    int BookId,
    int Qty);
