namespace MiniLibraryApi.Entities;

public class OrderBook : BaseEntity
{
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }
}