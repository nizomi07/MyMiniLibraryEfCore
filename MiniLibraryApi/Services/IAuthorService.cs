using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Responses;

namespace MiniLibraryApi.Services;

public interface IAuthorService
{
    Task<Response<Author>> AddAuthorAsync(AddAuthorDto authorDto);
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task<Response<Author>> UpdateAuthorAsync(UpdateAuthorDto authorDto);
    Task DeleteAuthorAsync(long id);
}