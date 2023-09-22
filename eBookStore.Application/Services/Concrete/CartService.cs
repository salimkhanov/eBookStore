using AutoMapper;
using eBookStore.Application.DTOs.CartItem;
using eBookStore.Application.Services.Abstract;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Repositories.EntityRepositories;

namespace eBookStore.Application.Services.Concrete;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IMapper _mapper;

    public CartService(
        ICartRepository cartRepository,
        ICartItemRepository cartItemRepository,
        IMapper mapper)
    {

        _cartRepository = cartRepository;
        _cartItemRepository = cartItemRepository;
        _mapper = mapper;
    }

    public async Task<bool> AddItemToCart(CartItemDTO cartItemDTO)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(cartItemDTO.UserId);

        if (cart == null)
        {
            cart = new Cart { UserId = cartItemDTO.UserId };
            await _cartRepository.AddAsync(cart);
        }

        var existingCartItem = cart.CartItems.FirstOrDefault(ci => ci.BookId == cartItemDTO.BookId);
        if (existingCartItem == null)
        {
            var newCartItem = _mapper.Map<CartItem>(cartItemDTO);
            newCartItem.CartId = cart.Id;
            await _cartItemRepository.AddAsync(newCartItem);
        }
        else
        {
            existingCartItem.Qty += cartItemDTO.Qty;
            await _cartItemRepository.UpdateAsync(existingCartItem);
        }

        return true;
    }

    public async Task ClearCart(int userId)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        await _cartItemRepository.ClearCartItemsAsync(cart.Id);
    }

    public async Task<List<CartItemDTO>> GetCartItemsAsync(int userId)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
        var cartItems = await _cartItemRepository.GetCartItemsByCartIdAsync(cart.Id);
        var cartItemDTOs = _mapper.Map<List<CartItemDTO>>(cartItems);

        return cartItemDTOs;
    }

    public async Task<bool> RemoveItemFromCart(int itemId)
    {
        var cartItem = await _cartItemRepository.GetByIdAsync(itemId);

        if (cartItem == null)
        {
            return false;
        }

        await _cartItemRepository.RemoveAsync(cartItem);

        return true;
    }

    public async Task UpdateCartItemQuantityAsync(int cartItemId, int quantity)
    {
        var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
        cartItem.Qty = quantity;
        await _cartItemRepository.UpdateAsync(cartItem);
    }
}
