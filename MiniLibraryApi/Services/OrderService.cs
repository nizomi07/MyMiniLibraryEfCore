using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public class OrderService(DataContext context) : IOrderService
{
    
    public async Task<Order> AddOrderAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
        return await context.Orders.ToListAsync();
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