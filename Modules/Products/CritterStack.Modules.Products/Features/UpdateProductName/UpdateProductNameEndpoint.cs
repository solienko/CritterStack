using CritterStack.Modules.Products.Contracts;
using CritterStack.Modules.Products.Domain;
using CritterStack.Modules.Products.Database;
using Microsoft.AspNetCore.Http;
using Wolverine.Http;

namespace CritterStack.Modules.Products.Features.UpdateProductName;

public static class UpdateProductNameEndpoint
{
    public static async Task<(Product? product, IResult response)> LoadAsync(Guid id, ProductsDbContext db)
    {
        var product = await db.Products.FindAsync(id);
        return product != null
            ? (product, new WolverineContinue())
            : (product, Results.NotFound());
    }

    [WolverinePut("api/products/{id}/name")]
    [Tags("Products Module")]
    [EndpointDescription("Update product name.")]
    [EndpointSummary("Update name")]
    public static (IResult, NameUpdated) Put(Guid id, UpdateNameRequest request, Product product, ProductsDbContext db)
    {
        product.SetName(request.Name);
        return
            (TypedResults.Ok(), new NameUpdated(product.Id, product.Name));
    }
}
