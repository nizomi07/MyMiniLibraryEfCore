using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public class BookService(DataContext context) : IBookService
{
    
    public async Task<Book> AddBookAsync(Book book)
    {
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await context.Books.ToListAsync();
    }

    public async Task<Book> UpdateBookAsync(Book book)
    {
        context.Books.Update(book);
        await context.SaveChangesAsync();
        return book;
    }

    public async Task DeleteBookAsync(long id)
    {
        var book = await context.Books.FindAsync(id);
        if (book != null)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }
    }
}