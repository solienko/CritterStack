using Wolverine.Http;

namespace CritterStack.Modules.Products.Contracts;

public record ProductCreationResponse(Guid Id)
    : CreationResponse("api/products/" + Id);
