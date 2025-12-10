using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Filters;
using MiniLibraryApi.Responses;

namespace MiniLibraryApi.Services;

public interface IBookService
{
    Task<Book> AddBookAsync(AddBookDto bookDto);
    Task<Response<ResponseGetList<IEnumerable<Book>>>> GetBooksAsync(BookFilter f);
    Task<Book> UpdateBookAsync(Book book);
    Task DeleteBookAsync(long id);
}