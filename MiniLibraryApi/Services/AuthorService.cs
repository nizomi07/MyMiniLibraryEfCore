using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public class AuthorService(DataContext context) : IAuthorService
{
    
    public async Task<Author> AddAuthorAsync(Author author)
    {
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await context.Authors.ToListAsync();
    }

    public async Task<Author> UpdateAuthorAsync(Author author)
    {
        context.Authors.Update(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task DeleteAuthorAsync(long id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author != null)
        {
            context.Authors.Remove(author);
            await context.SaveChangesAsync();
        }
    }
}