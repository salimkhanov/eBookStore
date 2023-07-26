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

    public async Task ClearCart()
    {
        throw new NotImplementedException();
    }

    public async Task<CartItemDTO> GetCartItemById(int id)
    {
        var cartItem = await _cartItemRepository.GetByIdAsync(id);
        return _mapper.Map<CartItemDTO>(cartItem);
    }

    public async Task<List<CartItemDTO>> GetCartItemsAsync()
    {
        var cartItem = await _cartItemRepository.GetAllAsync();
        return _mapper.Map<List<CartItemDTO>>(cartItem);
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

    public async Task<bool> SumbitCart(int userId)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);

        if (cart == null || cart.CartItems.Count == 0)
        {

            return false;
        }




        await _cartItemRepository.ClearCartItemsAsync(cart.Id);

        return true;
    }
}
