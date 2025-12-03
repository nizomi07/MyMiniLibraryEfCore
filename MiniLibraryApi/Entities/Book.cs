namespace MiniLibraryApi.Entities;

public class Book : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public long AuthorId { get; set; }
    public Author? Author { get; set; }
    
    public DateTime?  PublishDate { get; set; }
    
    public ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
}