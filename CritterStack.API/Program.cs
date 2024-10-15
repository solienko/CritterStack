using CritterStack.Modules.Customers;
using CritterStack.Modules.Products;
using Oakton;
using Oakton.Resources;
using Wolverine;
using Wolverine.EntityFrameworkCore;
using Wolverine.Http;
using Wolverine.SqlServer;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Host.ApplyOaktonExtensions();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddResourceSetupOnStartup();

builder.Services.AddWolverine(options =>
//builder.Host.UseWolverine(options =>
{
    options.Durability.Mode = DurabilityMode.Solo;

    options.PersistMessagesWithSqlServer(connectionString!, "wolverine");
    options.UseEntityFrameworkCoreTransactions();
    options.Policies.AutoApplyTransactions();
    options.Policies.UseDurableLocalQueues();

    options.Include<ProductsModule>(configure =>
    {
        configure.ConnectionString = connectionString;
    });

    options.Include<CustomersModule>(configure =>
    {
        configure.ConnectionString = connectionString;
    });

});

builder.Host.UseResourceSetupOnStartup();

builder.Services.AddWolverineHttp();

var app = builder.Build();

await app.Services.ApplyAsyncWolverineExtensions();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapWolverineEndpoints(options => 
{ 

});

await app.RunOaktonCommands(args);
