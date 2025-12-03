using Microsoft.EntityFrameworkCore;
using MiniLibraryApi.Entities;

namespace MiniLibraryApi.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderBook> OrderBooks { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Author>()
            .HasIndex(x => new { x.FirstName, x.LastName })
            .IsUnique();
            
        base.OnModelCreating(modelBuilder);
    }
}