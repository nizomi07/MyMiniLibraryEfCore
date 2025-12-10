using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Filters;
using MiniLibraryApi.Responses;

namespace MiniLibraryApi.Services;

public class AuthorService(DataContext context, IMapper mapper) : IAuthorService
{
    
    public async Task<Response<Author>> AddAuthorAsync(AddAuthorDto authorDto)
    {
        var author = mapper.Map<Author>(authorDto);
        context.Authors.Add(author);
        await context.SaveChangesAsync();
        return new Response<Author>(HttpStatusCode.OK, "Author added", author);
    }

    public async Task<Response<ResponseGetList<IEnumerable<Author>>>> GetAuthorsAsync(AuthorFilter f)
    {
        var query = context.Authors.AsQueryable();

        if (f.Id.HasValue)
            query = query.Where(x => x.Id == f.Id.Value);

        if (!string.IsNullOrEmpty(f.FirstName))
            query = query.Where(x => x.FirstName.ToLower().Contains(f.FirstName.ToLower()));
        if (!string.IsNullOrEmpty(f.LastName))
            query = query.Where(x => x.LastName.ToLower().Contains(f.LastName.ToLower()));
        
        var totalRecords = await query.CountAsync();

        var data = await query
            .Skip((f.Page - 1) * f.Size)
            .Take(f.Size)
            .ToListAsync();

        return new Response<ResponseGetList<IEnumerable<Author>>>
        {
            StatusCode = (int)HttpStatusCode.OK,
            Message = "Success",
            Content = new ResponseGetList<IEnumerable<Author>>
            {
                Data = data,
                Page = f.Page,
                Size = f.Size,
                TotalRecords = totalRecords
            }
        };
    }

    public async Task<Response<Author>> UpdateAuthorAsync(UpdateAuthorDto authorDto)
    {
        var author = mapper.Map<Author>(authorDto);
        context.Authors.Update(author);
        await context.SaveChangesAsync();
        return new Response<Author>(HttpStatusCode.OK, "Author updated", author);
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

