using CritterStack.Modules.Products.Contracts;
using CritterStack.Modules.Products.Domain;
using CritterStack.Modules.Products.Database;
using Microsoft.AspNetCore.Http;
using Wolverine.Http;

namespace CritterStack.Modules.Products.Features.CreateProduct;

public static class CreateProductEndpoint
{
    [WolverinePost("api/products")]
    [Tags("Products Module")]
    [EndpointDescription("Create new product.")]
    [EndpointSummary("Create product")]
    public static (ProductCreationResponse, ProductCreated) Post(CreateProductRequest command, ProductsDbContext db)
    {
        var product = new Product(command.Id, command.Name, command.Price, command.Stock);
        db.Products.Add(product);

        return (new ProductCreationResponse(product.Id), new ProductCreated(product.Id, product.Name));
    }
}
