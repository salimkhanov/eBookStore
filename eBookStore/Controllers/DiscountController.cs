using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Discount;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Discount")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class DiscountController : ControllerBase
{
    private readonly IDiscountService _discountService;

    public DiscountController(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetDiscountsAsync()
    {
        return Ok(await _discountService.GetDiscountsAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDiscountByIdAsync(int id)
    {
        var result = await _discountService.GetDiscountByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"Discount with ID {id} not found");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateDiscountAsync(DiscountDTO discountDTO)
    {
        if (await _discountService.UpdateDiscountAsync(discountDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDiscountAsync(int id)
    {
        if (await _discountService.DeleteDiscountAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateDiscountAsync(DiscountDTO discountDTO)
    {
        await _discountService.CreateDiscountAsync(discountDTO);
        return Ok(discountDTO);
    }

    [HttpPut("AddDiscountToBooks")]
    public async Task<IActionResult> AddDiscountToBooksAsync(DiscountBookDTO discountBookDTO)
    {
        if (await _discountService.AddDiscountToBooksAsync(discountBookDTO))
        {
            return Ok("Successfully added");
        }
        return NotFound();
    }

    [HttpPut("RemoveDiscountFromBooks")]
    public async Task<IActionResult> RemoveDiscountFromAllBooksAsync(int id)
    {
        if (await _discountService.RemoveDiscountFromAllBooksAsync(id))
        {
            return Ok("Successfully removed");
        }
        return NotFound();
    }
}
