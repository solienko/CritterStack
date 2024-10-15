using CritterStack.Modules.Customers.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CritterStack.Modules.Customers.Database.Mapping;

internal class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.HasData(GetSeedData());
    }

    private static IEnumerable<Customer> GetSeedData()
    {
        return
        [
            new(Guid.NewGuid(), "Customer 1"),
            new(Guid.NewGuid(), "Customer 2"),
            new(Guid.NewGuid(), "Customer 3"),
            new(Guid.NewGuid(), "Customer 4"),
        ];
    }
}
