using Microsoft.AspNetCore.Mvc;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Services;

namespace MiniLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderBookController(IOrderBookService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<OrderBook>> AddOrderBookAsync([FromBody] OrderBook orderBook)
    {
        var createdOrderBook = await service.AddOrderBookAsync(orderBook);
        return Ok(createdOrderBook);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderBook>>> GetAllOrderBooksAsync()
    {
        var categories = await service.GetOrderBooksAsync();
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<OrderBook>> UpdateOrderBookAsync([FromBody] OrderBook orderBook)
    {
        var updatedOrderBook = await service.UpdateOrderBookAsync(orderBook);
        return Ok(updatedOrderBook);
    }

    [HttpDelete]
    public async Task<ActionResult<OrderBook>> DeleteOrderBookAsync(long id)
    {
        await service.DeleteOrderBookAsync(id);
        return Ok();
    }
}