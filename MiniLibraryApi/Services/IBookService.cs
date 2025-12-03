using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public interface IBookService
{
    Task<Book> AddBookAsync(Book book);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task<Book> UpdateBookAsync(Book book);
    Task DeleteBookAsync(long id);
}