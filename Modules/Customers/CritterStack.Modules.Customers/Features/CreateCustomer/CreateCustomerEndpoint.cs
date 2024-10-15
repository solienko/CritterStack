using CritterStack.Modules.Customers.Contracts.Customers.Commands;
using CritterStack.Modules.Customers.Contracts.Customers.Events;
using CritterStack.Modules.Customers.Database;
using CritterStack.Modules.Customers.Domain;
using Microsoft.AspNetCore.Http;
using Wolverine.Http;

namespace CritterStack.Modules.Customers.Features.CreateCustomer;

public static class CreateCustomerEndpoint
{
    [WolverinePost("api/customers")]
    [Tags("Customers Module")]
    [EndpointDescription("Create new customer.")]
    [EndpointSummary("Create customer")]
    public static (IResult, CustomerCreated) Post(CreateCustomerCommand command, CustomersDbContext db)
    {
        var customer = new Customer(command.Id, command.Name);
        db.Customers.Add(customer);

        return (TypedResults.Ok(), new CustomerCreated(customer.Id, customer.Name));
    }
}
