using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Filters;
using MiniLibraryApi.Responses;

namespace MiniLibraryApi.Services;

public interface IAuthorService
{
    Task<Response<Author>> AddAuthorAsync(AddAuthorDto authorDto);
    Task<Response<Author>> UpdateAuthorAsync(UpdateAuthorDto authorDto);
    Task<Response<ResponseGetList<IEnumerable<Author>>>> GetAuthorsAsync(AuthorFilter f);
    Task DeleteAuthorAsync(long id);
}