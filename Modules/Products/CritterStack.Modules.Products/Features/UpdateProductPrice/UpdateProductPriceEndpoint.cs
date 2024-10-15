using CritterStack.Modules.Products.Contracts;
using CritterStack.Modules.Products.Domain;
using CritterStack.Modules.Products.Database;
using Microsoft.AspNetCore.Http;
using Wolverine.Http;

namespace CritterStack.Modules.Products.Features.UpdateProductPrice;

public static class UpdateProductPriceEndpoint
{
    public static async Task<(Product? product, IResult response)> LoadAsync(Guid id, ProductsDbContext db)
    {
        var product = await db.Products.FindAsync(id);
        return product != null
            ? (product, new WolverineContinue())
            : (product, Results.NotFound());
    }


    [WolverinePut("api/products/{id}/price")]
    [Tags("Products Module")]
    [EndpointDescription("Update product price.")]
    [EndpointSummary("Update price")]
    public static (IResult, PriceUpdated) Put(Guid id, UpdatePriceRequest request, Product product, ProductsDbContext db)
    {
        product.SetPrice(request.Price);
        return
            (TypedResults.Ok(), new PriceUpdated(product.Id, product.Price));
    }
}
