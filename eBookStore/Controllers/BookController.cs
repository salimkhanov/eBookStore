using eBookStore.Application.DTOs.Book;
using eBookStore.Application.DTOs.User;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Book")]
[ApiController]
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
    public async Task<IActionResult> UpdateBookAsync(BookRequestDTO bookRequestDTO)
    {
        if (await _bookService.UpdateBookAsync(bookRequestDTO))
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
    public async Task<IActionResult> CreateBookAsync(BookRequestDTO bookRequestDTO)
    {
        return Ok(await _bookService.CreateBookAsync(bookRequestDTO));
    }
}
