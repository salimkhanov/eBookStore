using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.OrderStatus;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class OrderStatusController : ControllerBase
{
    private readonly IOrderStatusService _orderStatusService;

    public OrderStatusController(IOrderStatusService orderStatusService)
    {
        _orderStatusService = orderStatusService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAddressAsync(OrderStatusDTO orderStatusDTO)
    {
        await _orderStatusService.CreateOrderStatus(orderStatusDTO);
        return Ok(orderStatusDTO);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetOrderStatusesAsync()
    {
        return Ok(await _orderStatusService.GetOrderStatusesAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetOrderStatusByIdAsync(int id)
    {
        var result = await _orderStatusService.GetOrderStatusByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateOrderStatusAsync(OrderStatusDTO orderStatusDTO)
    {
        if (await _orderStatusService.UpdateOrderStatusAsync(orderStatusDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteOrderStatusAsync(int id)
    {
        if (await _orderStatusService.DeleteOrderStatusAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }
}
