using CritterStack.Common;
using CritterStack.Modules.Customers.Database;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Wolverine;
using Wolverine.EntityFrameworkCore;

namespace CritterStack.Modules.Customers;

public class CustomersModule : ModuleBase
{
    public override void Configure(WolverineOptions options)
    {
        ArgumentNullException.ThrowIfNull(ConnectionString);

        options.Discovery.IncludeAssembly(Assembly.GetExecutingAssembly());

        options.Services.AddDbContextWithWolverineIntegration<CustomersDbContext>(options =>
        {
            options.UseSqlServer(ConnectionString);
        }, "wolverine");
    }
}
