using eBookStore.Application.DTOs.CartItem;
using eBookStore.Domain.Entities;

namespace eBookStore.Application.Services.Abstract;

public interface ICartService
{
    Task<List<CartItemDTO>> GetCartItemsAsync(int userId);
    Task<bool> AddItemToCart(CartItemDTO cartItemDTO);
    Task<bool> RemoveItemFromCart(int itemId);
    Task ClearCart(int userId);
    Task UpdateCartItemQuantityAsync(int cartItemId, int quantity);
}
