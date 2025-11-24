using System.ComponentModel.DataAnnotations;

namespace MiniLibraryApi.Entities;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
}