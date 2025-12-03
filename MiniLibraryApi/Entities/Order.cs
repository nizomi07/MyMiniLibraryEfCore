namespace MiniLibraryApi.Entities;

public class Order : BaseEntity
{
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
}
