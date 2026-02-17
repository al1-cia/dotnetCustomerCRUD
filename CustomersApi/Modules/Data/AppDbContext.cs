using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Modules;

public class AppDbContext : DbContext
{ //DbContext comes from Entity Framework core and represents a session with the database
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; } = null!;
}
