using CritterStack.Modules.Customers.Domain;
using Microsoft.EntityFrameworkCore;

namespace CritterStack.Modules.Customers.Database;

public class CustomersDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "CustomersModule";

    public DbSet<Customer> Customers { get; set; }

    public CustomersDbContext(DbContextOptions<CustomersDbContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomersDbContext).Assembly);
    }
}
