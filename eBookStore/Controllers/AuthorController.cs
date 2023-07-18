using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Book;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Author")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAuthorsAsync()
    {
        return Ok(await _authorService.GetAuthorsAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthorByIdAsync(int id)
    {
        var result = await _authorService.GetAuthorByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"Author with ID {id} not found");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateAuthorAsync(AuthorDTO authorDTO)
    {
        if (await _authorService.UpdateAuthorAsync(authorDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthorAsync(int id)
    {
        if (await _authorService.DeleteAuthorAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAuthorAsync(AuthorDTO authorDTO)
    {
        if(!await _authorService.CreateAuthorAsync(authorDTO))
        {
            return BadRequest("Author already exists");
        }
        return Ok(authorDTO);
    }
}
