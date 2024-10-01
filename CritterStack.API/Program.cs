using Oakton;
using Oakton.Resources;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ApplyOaktonExtensions();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddResourceSetupOnStartup();

builder.Host.UseWolverine(options =>
{
});

//builder.UseWolverine(options =>
//{
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
