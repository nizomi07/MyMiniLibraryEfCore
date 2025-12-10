using Microsoft.AspNetCore.Mvc;
using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Filters;
using MiniLibraryApi.Services;

namespace MiniLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Author>> AddAuthorAsync([FromBody] AddAuthorDto authorDto)
    {
        var createdAuthor = await service.AddAuthorAsync(authorDto);
        return Ok(createdAuthor);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthorsAsync(AuthorFilter filter)
    {
        var categories = await service.GetAuthorsAsync(filter);
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<Author>> UpdateAuthorAsync([FromBody] UpdateAuthorDto authorDto)
    {
        var updatedAuthor = await service.UpdateAuthorAsync(authorDto);
        return Ok(updatedAuthor);
    }

    [HttpDelete]
    public async Task<ActionResult<Author>> DeleteAuthorAsync(long id)
    {
        await service.DeleteAuthorAsync(id);
        return Ok();
    }
}