using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public interface IAuthorService
{
    Task<Author> AddAuthorAsync(AddAuthorDto authorDto);
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> UpdateAuthorAsync(UpdateAuthorDto authorDto);
    Task DeleteAuthorAsync(long id);
}