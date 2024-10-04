using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsModule;
using ProductsModule.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wolverine;
using Wolverine.Attributes;

[assembly: WolverineModule<ProductsModuleExtension>]

namespace ProductsModule;

public class ProductsModuleExtension : IWolverineExtension
{
    private readonly IConfiguration _configuration;

    public ProductsModuleExtension(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(WolverineOptions options)
    {
        options.Services.AddDbContext<ProductsDbContext>(options =>
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        });
    }
}
