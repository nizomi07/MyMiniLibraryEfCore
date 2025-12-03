using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Services;

public interface IOrderService
{
    Task<Order> AddOrderAsync(Order order);
    Task<IEnumerable<Order>> GetOrdersAsync();
    Task<Order> UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(long id);
}