using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniLibraryApi.Entities;

[Table("BookAuthor")]
public class Author : BaseEntity
{
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    
    public ICollection<Book>? Books { get; set; }
}