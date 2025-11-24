using Microsoft.AspNetCore.Mvc;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Services;

namespace MiniLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Author>> AddAuthorAsync([FromForm] Author author)
    {
        var createdAuthor = await service.AddAuthorAsync(author);
        return Ok(createdAuthor);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthorsAsync()
    {
        var categories = await service.GetAuthorsAsync();
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<Author>> UpdateAuthorAsync([FromForm] Author author)
    {
        var updatedAuthor = await service.UpdateAuthorAsync(author);
        return Ok(updatedAuthor);
    }

    [HttpDelete]
    public async Task<ActionResult<Author>> DeleteAuthorAsync(long id)
    {
        await service.DeleteAuthorAsync(id);
        return Ok();
    }
}