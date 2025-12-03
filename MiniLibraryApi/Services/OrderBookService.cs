using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Data;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public class OrderBookService(DataContext context) : IOrderBookService
{
    public async Task<OrderBook> AddOrderBookAsync(OrderBook orderBook)
    {
        context.OrderBooks.Add(orderBook);
        await context.SaveChangesAsync();
        return orderBook;
    }

    public async Task<IEnumerable<OrderBook>> GetOrderBooksAsync()
    {
        return await context.OrderBooks.ToListAsync();
    }

    public async Task<OrderBook> UpdateOrderBookAsync(OrderBook orderBook)
    {
        context.OrderBooks.Update(orderBook);
        await context.SaveChangesAsync();
        return orderBook;
    }

    public async Task DeleteOrderBookAsync(long id)
    {
        var orderBook = await context.OrderBooks.FindAsync(id);
        if (orderBook != null)
        {
            context.OrderBooks.Remove(orderBook);
            await context.SaveChangesAsync();
        }
    }
}