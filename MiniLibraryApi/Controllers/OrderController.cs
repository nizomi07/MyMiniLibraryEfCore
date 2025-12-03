using Microsoft.AspNetCore.Mvc;
using MiniLibraryApi.Entities;
using MiniLibraryApi.Services;

namespace MiniLibraryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Order>> AddOrderAsync([FromForm] Order order)
    {
        var createdOrder = await service.AddOrderAsync(order);
        return Ok(createdOrder);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersAsync()
    {
        var categories = await service.GetOrdersAsync();
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<Order>> UpdateOrderAsync([FromForm] Order order)
    {
        var updatedOrder = await service.UpdateOrderAsync(order);
        return Ok(updatedOrder);
    }

    [HttpDelete]
    public async Task<ActionResult<Order>> DeleteOrderAsync(long id)
    {
        await service.DeleteOrderAsync(id);
        return Ok();
    }
}