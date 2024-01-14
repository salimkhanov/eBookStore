using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.BookGenre;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("BookGenre")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class BookGenreController : ControllerBase
{
    private readonly IBookGenreService _bookGenreService;

    public BookGenreController(IBookGenreService bookGenreService)
    {
        _bookGenreService = bookGenreService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetGenresAsync()
    {
        return Ok(await _bookGenreService.GetGenresAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetGenreByIdAsync(int id)
    {
        var result = await _bookGenreService.GetGenreByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound();
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateGenreAsync(BookGenreDTO bookGenreDTO)
    {
        if (await _bookGenreService.UpdateGenreAsync(bookGenreDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteGenreAsync(int id)   
    {
        if (await _bookGenreService.DeleteGenreAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateGenreAsync(BookGenreDTO bookGenreDTO)
    {
        if (!await _bookGenreService.CreateGenreAsync(bookGenreDTO))
        {
            return BadRequest("Genre already exists");
        }
        return Ok(bookGenreDTO);
    }
}
