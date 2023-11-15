using eBookStore.Application.DTOs.BookGenre;
using eBookStore.Application.DTOs.Order;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Order")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderCreateDTO orderCreateDTO)
    {
        await _orderService.CreateOrder(orderCreateDTO);
        return Ok(orderCreateDTO);
    }

    [HttpPut]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        if(await _orderService.DeleteOrderAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpGet("GetOrdersByUserIdAsync")]
    public async Task<IActionResult> GetOrdersByUserIdAsync(int userId)
    {
        return Ok(await _orderService.GetOrdersByUserIdAsync(userId));
    }

    [HttpPut("UpdateOrder")]
    public async Task<IActionResult> UpdateOrderAsync(BookGenreDTO bookGenreDTO)
    {
        if (await _orderService.UpdateOrderAsync(bookGenreDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpPost("ChangeStatus")]
    public async Task<IActionResult> ChangeOrderStatus(int orderId, int statusId)
    {
        var result = await _orderService.ChangeOrderStatus(orderId, statusId);

        if (result)
        {
            return Ok("Order status changed successfully");
        }

        return NotFound("Order or status not found");
    }
}
