using CritterStack.Modules.Customers.Domain;
using CritterStack.Modules.Customers.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Wolverine.Http;

namespace CritterStack.Modules.Customers.Features.GetCustomers;

public static class GetCustomersEndpoint
{
    [WolverineGet("api/customers")]
    [Tags("Customers Module")]
    [EndpointDescription("Get all customers.")]
    [EndpointSummary("Get customers")]
    public static async Task<List<Customer>> Get(CustomersDbContext db)
    {
        return await db.Customers.OrderBy(x => x.Name).ToListAsync();
    }
}
