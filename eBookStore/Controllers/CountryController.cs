using eBookStore.Application.DTOs.Country;
using eBookStore.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Country")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetCountriesAsync()    
    {
        return Ok(await _countryService.GetCountriesAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCountryByIdAsync(int id)    
    {
        var result = await _countryService.GetCountryByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"Country with ID {id} not found");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateCountryAsync(CountryDTO countryDTO)
    {
        if (await _countryService.UpdateCountryAsync(countryDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCountryAsync(int id)
    {
        if (await _countryService.DeleteCountryAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateCountryAsync(CountryDTO countryDTO)
    {
        if (!await _countryService.CreateCountryAsync(countryDTO))
        {
            return BadRequest("Author already exists");
        }
        return Ok(countryDTO);
    }
}
