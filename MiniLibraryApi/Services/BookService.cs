using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public class BookService(DataContext context, IMapper mapper) : IBookService
{
    
    public async Task<Book> AddBookAsync(AddBookDto bookDto)
    {
        var book = mapper.Map<Book>(bookDto);
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