using CustomersApi.Modules;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register modules
// builder.Services.AddCustomersModule(); // Registers services (Dependency Injection container)

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();

var app = builder.Build();

app.MapCustomersEndpoints();

app.Run();