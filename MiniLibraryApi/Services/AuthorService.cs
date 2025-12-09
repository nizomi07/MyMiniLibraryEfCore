using System.Net;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.DTOs;
using MiniLibraryApi.Entities;
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

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await context.Authors.ToListAsync();
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



//
//
// public async Task<Response<ResponseGetList<IEnumerable<Category>>>> GetCategoriesAsync(CategoryFilter f)
// {
//     var query = context.Categories
//         .Include(x => x.Books!)
//         .ThenInclude(x => x.Author)
//         .AsQueryable();
//
//     if (f.Id.HasValue) query = query.Where(x => x.Id == f.Id.Value);
//     if (!string.IsNullOrEmpty(f.Name)) query = query.Where(x => x.Name.Contains(f.Name));
//     if (!string.IsNullOrEmpty(f.Description))
//         query = query.Where(x => x.Description != null && x.Description.Contains(f.Description));
//
//     return new Response<ResponseGetList<IEnumerable<Category>>>
//     {
//         Code = (int)HttpStatusCode.OK,
//         Message = "Success",
//         Payload = new ResponseGetList<IEnumerable<Category>>
//         {
//             Data = await query
//                 .Skip((f.Page-1) * f.Size)
//                 .Take(f.Size)
//                 .ToListAsync(),
//             Page = f.Page,
//             Size = f.Size,
//             TotalRecords = await query.CountAsync()
//         }
//     };
// }
