using CritterStack.Modules.Products.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CritterStack.Modules.Products.Database.Mapping;

internal class ProductTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.Property(x => x.Price)
            .HasColumnType("decimal(18, 2)");

        builder.HasData(GetSeedData());
    }

    private static IEnumerable<Product> GetSeedData()
    {
        return
        [
            new(Guid.NewGuid(), "Product 1", 10, 100),
            new(Guid.NewGuid(), "Product 2", 20, 200),
            new(Guid.NewGuid(), "Product 3", 30, 300),
            new(Guid.NewGuid(), "Product 4", 40, 400),
        ];
    }
}
