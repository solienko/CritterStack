using CritterStack.Modules.Products.Contracts;

namespace CritterStack.API.Handlers;

public class ProductCreatedHandler
{
    public static void Handle(ProductCreated productCreated)
    {
        Console.WriteLine($"EVENT HANDLED: New Product created: {productCreated.Id} - {productCreated.Name}");
    }
}
