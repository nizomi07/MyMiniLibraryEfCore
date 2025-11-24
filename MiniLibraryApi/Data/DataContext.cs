using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
}