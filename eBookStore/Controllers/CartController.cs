using eBookStore.Application.DTOs.CartItem;
using eBookStore.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]

public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet("GetItems")]
    public async Task<IActionResult> GetCartItemsAsync()
    {
        return Ok(await _cartService.GetCartItemsAsync());
    }

    [HttpPost("AddItem")]
    public async Task<IActionResult> AddItemToCart(CartItemDTO cartItemDTO)
    {
        if(await _cartService.AddItemToCart(cartItemDTO))
        {
            return Ok(cartItemDTO);
        }
        return BadRequest();
    }

    [HttpPost("RemoveItem")]
    public async Task<IActionResult> RemoveItemFromCart(int itemId)
    {
        if (await _cartService.RemoveItemFromCart(itemId))
        {
            return Ok("Successfully removed");
        }
        return BadRequest();
    }

    [HttpPost("Clear")]
    public async Task<IActionResult> ClearCart()
    {
        await _cartService.ClearCart();
        return Ok("Cart cleaned");
    }

    [HttpPost("UpdateQuantity")]
    public async Task<IActionResult> UpdateCartItemQuantity(int cartItemId, int quantity)
    {
        await _cartService.UpdateCartItemQuantityAsync(cartItemId, quantity);
        return Ok("Item quantity updated");
    }
}
