using Microsoft.EntityFrameworkCore;
using OrderSystem.Data;
using OrderSystem.Repositories;
using OrderSystem.Services;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(
   builder.Configuration.GetConnectionString("DefaultConnection"),
   sql => sql.EnableRetryOnFailure()
));

// .NET 9 built-in OpenAPI generator
builder.Services.AddOpenApi();

// Register Dependencies 
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IGoodsRepository, GoodsRepository>();
builder.Services.AddScoped<IGoodsService, GoodsService>();

var app = builder.Build();

// Generates OpenAPI document
app.MapOpenApi();
	
if (app.Environment.IsDevelopment())
{
    // Swagger visual UI
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OrderSystem API v1 (Development)");
        options.RoutePrefix = "swagger"; // URL path
    });
}
else // in Production
{
    // Swagger visual UI
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OrderSystem API v1 (Production)");
        options.RoutePrefix = "swagger"; // URL path
    });
}

app.MapControllers();
Debug.WriteLine($"Done app.MapControllers,  \n will add data (if none)");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();   // ensures DB exists
    await DbSeeder.SeedAsync(db);       // seed data
}
Debug.WriteLine($"Done add data");

app.Run();
