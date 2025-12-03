using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public interface IOrderBookService
{
    Task<OrderBook> AddOrderBookAsync(OrderBook orderBook);
    Task<IEnumerable<OrderBook>> GetOrderBooksAsync();
    Task<OrderBook> UpdateOrderBookAsync(OrderBook orderBook);
    Task DeleteOrderBookAsync(long id);
}