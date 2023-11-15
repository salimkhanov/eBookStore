using eBookStore.Application.DTOs.Address;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAddressAsync(AddressRequestDTO addressRequestDTO)
    {
        await _addressService.CreateAddressAsync(addressRequestDTO);
        return Ok(addressRequestDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAddressAsync(int id)
    {
        if(await _addressService.DeleteAddressAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAddressByIdAsync(int id)
    {
        var result = await _addressService.GetAddressByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"Address with ID {id} not found");
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAddressesAsync()
    {
        return Ok(await _addressService.GetAddressesAsync());
    }

    [HttpGet("GetUserAddresses")]
    public async Task<IActionResult> GetUserAddressesAsync()
    {
        return Ok(await _addressService.GetUserAddressesAsync());   
    }

    [HttpPut("MakeAsDefault")]
    public async Task<IActionResult> MakeAsDefaultAsync(int id)
    {
        if(await _addressService.MakeAsDefaultAsync(id))
        {
            return Ok("Successfully completed");
        }

        return NotFound();
    }

    [HttpPut("UpdateAddress")]
    public async Task<IActionResult> UpdateAddressAsync(AddressRequestDTO address)
    {
        if(await _addressService.UpdateAddressAsync(address))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }
}
