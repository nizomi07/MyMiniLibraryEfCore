using MiniLibraryApi.Entities;
using MiniLibraryApi.Filters;
using MiniLibraryApi.Responses;

namespace MiniLibraryApi.Services;

public interface IOrderService
{
    Task<Order> AddOrderAsync(Order order);
    Task<Response<ResponseGetList<IEnumerable<Order>>>> GetOrdersAsync(OrderFilter f);
    Task<Order> UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(long id);
}