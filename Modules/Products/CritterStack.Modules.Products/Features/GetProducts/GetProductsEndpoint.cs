using CritterStack.Modules.Products.Domain;
using CritterStack.Modules.Products.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Wolverine.Http;

namespace CritterStack.Modules.Products.Features.GetProducts;

public static class GetProductsEndpoint
{
    [WolverineGet("api/products")]
    [Tags("Products Module")]
    [EndpointDescription("Get all products.")]
    [EndpointSummary("Get products")]
    public static async Task<List<Product>> Get(ProductsDbContext db)
    {
        return await db.Products.OrderBy(x => x.Name).ToListAsync();
    }
}
