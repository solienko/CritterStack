using Oakton;
using Oakton.Resources;
using ProductsModule;
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

builder.Host.UseWolverine(options =>
{
    options.PersistMessagesWithSqlServer(connectionString!, "wolverine");
    options.UseEntityFrameworkCoreTransactions();
    options.Policies.AutoApplyTransactions();
    options.Policies.UseDurableLocalQueues();

    options.Discovery.IncludeAssembly(typeof(ProductsModuleExtension).Assembly);

    if (builder.Environment.IsDevelopment())
    {
        options.Durability.Mode = DurabilityMode.Solo;
    }
});

builder.Host.UseResourceSetupOnStartup();

builder.Services.AddWolverineHttp();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapWolverineEndpoints();


await app.RunOaktonCommands(args);
