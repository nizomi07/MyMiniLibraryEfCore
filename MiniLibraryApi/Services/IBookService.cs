using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public interface IBookService
{
    Task<Book> AddBookAsync(AddBookDto bookDto);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> UpdateBookAsync(Book book);
    Task DeleteBookAsync(long id);
}