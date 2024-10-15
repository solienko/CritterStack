using CritterStack.Modules.Products.Contracts;
using CritterStack.Modules.Products.Domain;
using CritterStack.Modules.Products.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wolverine.Http;

namespace CritterStack.Modules.Products.Features.DeleteProduct;

public static class DeleteProductEndpoint
{
    [WolverineDelete("api/products/{id}")]
    [Tags("Products Module")]
    [EndpointDescription("Delete product.")]
    [EndpointSummary("Delete product")]
    public static (IResult, ProductDeleted?) Delete(Guid id, [NotBody] ProductsDbContext db)
    {
        if (db.Products.Find(id) is Product product)
        {
            db.Products.Remove(product);
            return (TypedResults.Ok(), new ProductDeleted(id));
        }

        return (TypedResults.NotFound(), null);
    }
}
