using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public interface IAuthorService
{
    Task<Author> AddAuthorAsync(Author author);
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Author> UpdateAuthorAsync(Author author);
    Task DeleteAuthorAsync(long id);
}