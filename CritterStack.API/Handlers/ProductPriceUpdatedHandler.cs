using CritterStack.Modules.Products.Contracts;

namespace CritterStack.API.Handlers;

public class ProductPriceUpdatedHandler
{
    public static void Handle(PriceUpdated priceUpdated)
    {
        Console.WriteLine($"EVENT HANDLED: Product price updated: {priceUpdated.Id} - {priceUpdated.Price}");
    }
}
