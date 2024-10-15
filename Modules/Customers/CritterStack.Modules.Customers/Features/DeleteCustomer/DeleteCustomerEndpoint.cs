using CritterStack.Modules.Customers.Contracts.Customers.Events;
using CritterStack.Modules.Customers.Database;
using CritterStack.Modules.Customers.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolverine.Http;

namespace CritterStack.Modules.Customers.Features.DeleteCustomer;

public static class DeleteCustomerEndpoint
{
    [WolverineDelete("api/customers/{id}")]
    [Tags("Customers Module")]
    [EndpointDescription("Delete customer.")]
    [EndpointSummary("Delete customer")]
    public static (IResult, CustomerDeleted?) Delete(Guid id, [FromServices] CustomersDbContext db)
    {
        if (db.Customers.Find(id) is Customer customer)
        {
            db.Customers.Remove(customer);
            return (TypedResults.Ok(), new CustomerDeleted(id));
        }

        return (TypedResults.NotFound(), null);
    }
}
