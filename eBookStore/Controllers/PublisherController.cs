using eBookStore.Application.DTOs.Author;
using eBookStore.Application.DTOs.Book;
using eBookStore.Application.DTOs.Publisher;
using eBookStore.Application.Services.Abstract;
using eBookStore.Application.Services.Concrete;
using eBookStore.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eBookStore.Controllers;

[Route("Publisher")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetPublishersAsync()
    {
        return Ok(await _publisherService.GetPublishersAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPublisherByIdAsync(int id)
    {
        var result = await _publisherService.GetPublisherByIdAsync(id);
        if (result != null)
        {
            return Ok(result);
        }
        return NotFound($"Publisher with ID {id} not found");
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdatePublisherAsync(PublisherDTO publisherDTO)
    {
        if (await _publisherService.UpdatePublisherAsync(publisherDTO))
        {
            return Ok("Successfully updated");
        }
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePublisherAsync(int id)
    {
        if (await _publisherService.DeletePublisherAsync(id))
        {
            return Ok("Successfully deleted");
        }
        return NotFound();
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreatePublisherAsync(PublisherDTO publisherDTO)
    {
        if (!await _publisherService.CreatePublisherAsync(publisherDTO))
        {
            return BadRequest("Author already exists");
        }
        return Ok(publisherDTO);
    }
}
