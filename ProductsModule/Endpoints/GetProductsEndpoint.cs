using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ProductsModule.Data;
using ProductsModule.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolverine.Http;

namespace ProductsModule.Endpoints;

public static class GetProductsEndpoint
{
    [WolverineGet("api/products")]
    [Tags("Products Module")]
    [EndpointDescription("Get all products.")]
    [EndpointSummary("Get products")]

    public static async Task<List<Product>> GetProducts(ProductsDbContext db)
    {
        return await db.Products.ToListAsync();
    }
}
