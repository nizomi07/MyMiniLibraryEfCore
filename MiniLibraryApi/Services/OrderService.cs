using System.Net;
using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Filters;
using MiniLibraryApi.Responses;

namespace MiniLibraryApi.Services;

public class OrderService(DataContext context) : IOrderService
{
    
    public async Task<Order> AddOrderAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<Response<ResponseGetList<IEnumerable<Order>>>> GetOrdersAsync(OrderFilter f)
    {
        var query = context.Orders.AsQueryable();

        if (f.Id.HasValue)
            query = query.Where(x => x.Id == f.Id.Value);

        if (!string.IsNullOrEmpty(f.CustomerName))
            query = query.Where(x => x.CustomerName.ToLower().Contains(f.CustomerName.ToLower()));

        if (!string.IsNullOrEmpty(f.CustomerEmail))
            query = query.Where(x => x.CustomerEmail!.ToLower().Contains(f.CustomerEmail.ToLower()));


        var totalRecords = await query.CountAsync();

        var data = await query
            .Skip((f.Page - 1) * f.Size)
            .Take(f.Size)
            .ToListAsync();

        return new Response<ResponseGetList<IEnumerable<Order>>>
        {
            StatusCode = (int)HttpStatusCode.OK,
            Message = "Success",
            Content = new ResponseGetList<IEnumerable<Order>>
            {
                Data = data,
                Page = f.Page,
                Size = f.Size,
                TotalRecords = totalRecords
            }
        };
    }

    public async Task<Order> UpdateOrderAsync(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task DeleteOrderAsync(long id)
    {
        var order = await context.Orders.FindAsync(id);
        if (order != null)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
    }
}