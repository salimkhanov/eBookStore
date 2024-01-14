using eBookStore.Application.DTOs.Book;
using eBookStore.Application.DTOs.User;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Book")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetBooksAsync()
    {
        return Ok(await _bookService.GetBooksAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBookByIdAsync(int id)
    {
        var result = await _bookService.GetBookByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"Book with ID {id} not found");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateBookAsync(BookUpdateDTO bookUpdateDTO)
    {
        if (await _bookService.UpdateBookAsync(bookUpdateDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBookAsync(int id) 
    {
        if (await _bookService.DeleteBookAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateBookAsync([FromForm] BookCreateDTO bookCreateDTO)
    {
        if(await _bookService.CreateBookAsync(bookCreateDTO))
        {
            return Ok(bookCreateDTO);
        }
        return BadRequest();
    }
}
