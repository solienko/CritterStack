using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsModule.Data;

internal class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.HasData(GetSeedData());
    }

    private static IEnumerable<Product> GetSeedData()
    {
        return
        [
            new() {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Price = 10,
                Stock = 100
            },
            new() {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 20,
                Stock = 200
            },
            new() {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Price = 30,
                Stock = 300
            }
        ];
    }
}
