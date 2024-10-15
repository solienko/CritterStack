namespace CritterStack.Modules.Products.Contracts;

public record CreateProductRequest(Guid Id, string Name, decimal Price, int Stock);
