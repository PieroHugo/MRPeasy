using Microsoft.EntityFrameworkCore;
using MRPeasy.API.Inventories.Application.Internal.CommandServices;
using MRPeasy.API.Inventories.Application.Internal.QueryServices;
using MRPeasy.API.Inventories.Domain.Repositories;
using MRPeasy.API.Inventories.Domain.Services;
using MRPeasy.API.Inventories.Infrastructure.Repositories;
using MRPeasy.API.Manufacturing.Application.Internal.CommandServices;
using MRPeasy.API.Manufacturing.Domain.Repositories;
using MRPeasy.API.Manufacturing.Domain.Services;
using MRPeasy.API.Manufacturing.Infrastructure.Repositories;
using MRPeasy.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using MRPeasy.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBillOfMaterialsItemRepository, BillOfMaterialsItemRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IBillOfMaterialsItemCommandService, BillOfMaterialsItemCommandService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.EnsureDatabaseCreatedOrMigrated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
// Use Swagger for API documentation if in development mode
//if (app.Environment.IsDevelopment())
//{
//   app.UseSwagger();
//   app.UseSwaggerUI();
//}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();