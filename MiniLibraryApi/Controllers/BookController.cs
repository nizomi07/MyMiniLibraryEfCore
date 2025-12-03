using Microsoft.AspNetCore.Mvc;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Services;

namespace MiniLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Book>> AddBookAsync([FromForm] Book book)
    {
        var createdBook = await service.AddBookAsync(book);
        return Ok(createdBook);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksAsync()
    {
        var categories = await service.GetBooksAsync();
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<Book>> UpdateBookAsync([FromForm] Book book)
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