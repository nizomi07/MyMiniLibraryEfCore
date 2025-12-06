namespace MiniLibraryApi.DTOs;

public class AddBookDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public long AuthorId { get; set; }
    public DateTime PublishDate { get; set; }
}