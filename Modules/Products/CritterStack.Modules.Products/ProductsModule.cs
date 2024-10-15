using CritterStack.Common;
using CritterStack.Modules.Products.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Wolverine;
using Wolverine.EntityFrameworkCore;

namespace CritterStack.Modules.Products;

public class ProductsModule : ModuleBase
{
    public override void Configure(WolverineOptions options)
    {
        ArgumentNullException.ThrowIfNull(ConnectionString);

        options.Discovery.IncludeAssembly(Assembly.GetExecutingAssembly());

        options.Services.AddDbContextWithWolverineIntegration<ProductsDbContext>(options =>
        {
            options.UseSqlServer(ConnectionString);
        }, "wolverine");
    }
}
