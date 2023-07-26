using eBookStore.Application.DTOs.CartItem;
using eBookStore.Domain.Entities;

namespace eBookStore.Application.Services.Abstract;

public interface ICartService
{
    Task<List<CartItemDTO>> GetCartItemsAsync();
    Task<CartItemDTO> GetCartItemById(int id);
    Task<bool> AddItemToCart(CartItemDTO cartItemDTO);
    Task<bool> RemoveItemFromCart(int itemId);
    Task<bool> SumbitCart(int userId);
    Task ClearCart();
}
