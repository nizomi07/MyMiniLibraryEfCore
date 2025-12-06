using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public class AuthorService(DataContext context, IMapper mapper) : IAuthorService
{
    
    public async Task<Author> AddAuthorAsync(AddAuthorDto authorDto)
    {
        var author = mapper.Map<Author>(authorDto);
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await context.Authors.ToListAsync();
    }

    public async Task<Author> UpdateAuthorAsync(UpdateAuthorDto authorDto)
    {
        var author = mapper.Map<Author>(authorDto);
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