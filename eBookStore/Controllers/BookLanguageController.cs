using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.BookLanguage;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("BookLanguage")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class BookLanguageController : ControllerBase
{
    private readonly IBookLanguageService _bookLanguageService;

    public BookLanguageController(IBookLanguageService bookLanguageService)
    {
        _bookLanguageService = bookLanguageService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetLanguagesAsync()    
    {
        return Ok(await _bookLanguageService.GetLanguagesAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetLanguageByIdAsync(int id)    
    {
        var result = await _bookLanguageService.GetLanguageByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"Language with ID {id} not found");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateLanguageAsync(BookLanguageDTO bookLanguageDTO)
    {
        if (await _bookLanguageService.UpdateLanguageAsync(bookLanguageDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteLanguageAsync(int id)
    {
        if (await _bookLanguageService.DeleteLanguageAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateLanguageAsync(BookLanguageDTO bookLanguageDTO)
    {
        if (!await _bookLanguageService.CreateLanguageAsync(bookLanguageDTO))
        {
            return BadRequest("Language already exists");
        }
        return Ok(bookLanguageDTO); 
    }
}
