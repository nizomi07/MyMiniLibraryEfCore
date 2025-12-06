using Microsoft.AspNetCore.Mvc;
using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Services;

namespace MiniLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Book>> AddBookAsync([FromBody] AddBookDto bookDto)
    {
        var createdBook = await service.AddBookAsync(bookDto);
        return Ok(createdBook);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksAsync()
    {
        var categories = await service.GetBooksAsync();
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<Book>> UpdateBookAsync([FromBody] Book book)
    {
        var updatedBook = await service.UpdateBookAsync(book);
        return Ok(updatedBook);
    }

    [HttpDelete]
    public async Task<ActionResult<Book>> DeleteBookAsync(long id)
    {
        await service.DeleteBookAsync(id);
        return Ok();
    }
}