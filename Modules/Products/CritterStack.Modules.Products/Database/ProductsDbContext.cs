using CritterStack.Modules.Products.Domain;
using Microsoft.EntityFrameworkCore;

namespace CritterStack.Modules.Products.Database;

public class ProductsDbContext : DbContext
{
    public const string DEFAULT_SCHEMA = "ProductsModule";

    public DbSet<Product> Products { get; set; }

    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsDbContext).Assembly);
    }
}
