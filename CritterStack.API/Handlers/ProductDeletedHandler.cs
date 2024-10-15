using CritterStack.Modules.Products.Contracts;

namespace CritterStack.API.Handlers;

public class ProductDeletedHandler
{
    public static void Handle(ProductDeleted productDeleted)
    {
        Console.WriteLine($"EVENT HANDLED: Product was created: {productDeleted.Id}");
    }
}
