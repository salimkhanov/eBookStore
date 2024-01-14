using eBookStore.Application.DTOs.CartItem;
using eBookStore.Domain.Entities;

namespace eBookStore.Application.Services.Abstract;

public interface ICartService
{
    Task<List<CartItemDTO>> GetCartItemsAsync();
    Task<bool> AddItemToCart(CartItemDTO cartItemDTO);
    Task<bool> RemoveItemFromCart(int itemId);
    Task ClearCart();
    Task UpdateCartItemQuantityAsync(int cartItemId, int quantity);
}
