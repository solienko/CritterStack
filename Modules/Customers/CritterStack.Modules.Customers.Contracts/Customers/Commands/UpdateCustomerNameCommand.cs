namespace CritterStack.Modules.Customers.Contracts.Customers.Commands;

public record UpdateCustomerNameCommand(Guid Id, string Name);
