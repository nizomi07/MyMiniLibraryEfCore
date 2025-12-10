using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Filters;
using MiniLibraryApi.Responses;

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
    
    public async Task<Response<ResponseGetList<IEnumerable<Book>>>> GetBooksAsync(BookFilter f)
    {
        var query = context.Books.AsQueryable();

        if (f.Id.HasValue)
            query = query.Where(x => x.Id == f.Id.Value);

        if (!string.IsNullOrEmpty(f.Name))
            query = query.Where(x => x.Name.ToLower().Contains(f.Name.ToLower()));

        if (!string.IsNullOrEmpty(f.Description))
            query = query.Where(x => x.Description!.ToLower().Contains(f.Description.ToLower()));


        var totalRecords = await query.CountAsync();

        var data = await query
            .Skip((f.Page - 1) * f.Size)
            .Take(f.Size)
            .ToListAsync();

        return new Response<ResponseGetList<IEnumerable<Book>>>
        {
            StatusCode = (int)HttpStatusCode.OK,
            Message = "Success",
            Content = new ResponseGetList<IEnumerable<Book>>
            {
                Data = data,
                Page = f.Page,
                Size = f.Size,
                TotalRecords = totalRecords
            }
        };
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