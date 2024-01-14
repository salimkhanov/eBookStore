using eBookStore.Application.DTOs.Address;
using eBookStore.Application.DTOs.PaymentMethod;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class PaymentMethodController : ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;

    public PaymentMethodController(IPaymentMethodService paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreatePaymentMethodAsync(PaymentMethodRequestDTO paymentMethod)
    {
        await _paymentMethodService.CreatePaymentMethodAsync(paymentMethod);
        return Ok(paymentMethod);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePaymentMethodAsync(int id)
    {
        if (await _paymentMethodService.DeletePaymentMethodAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPaymentMethodByIdAsync(int id)
    {
        var result = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"Payment method with ID {id} not found");
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetPaymentMethodsAsync()
    {
        return Ok(await _paymentMethodService.GetPaymentMethodsAsync());
    }

    [HttpGet("GetUserPaymentMethods")]
    public async Task<IActionResult> GetUserPaymentMethodsAsync()
    {
        return Ok(await _paymentMethodService.GetUserPaymentMethodsAsync());
    }

    [HttpPut("MakeAsDefault")]
    public async Task<IActionResult> MakeAsDefaultAsync(int id)
    {
        if (await _paymentMethodService.MakeAsDefaultAsync(id))
        {
            return Ok("Successfully completed");
        }

        return NotFound();
    }

    [HttpPut("UpdatePaymentMethod")]
    public async Task<IActionResult> UpdatePaymentMethodAsync(PaymentMethodRequestDTO paymentMethod)
    {
        if (await _paymentMethodService.UpdatePaymentMethodAsync(paymentMethod))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }
}
