using Microsoft.EntityFrameworkCore;
using ProductsModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsModule.Data;

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
    }
}
