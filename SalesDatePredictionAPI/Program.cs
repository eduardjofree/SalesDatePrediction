using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using SalesDatePredictionAPI.Data;
using SalesDatePredictionAPI.Interfaces;
using SalesDatePredictionAPI.Repositories;
using SalesDatePredictionAPI.Services;
using System.Runtime.Intrinsics.X86;

var builder = WebApplication.CreateBuilder(args);

// Obtener cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar servicios de infraestructura y aplicación
builder.Services.AddDbContext<StoreSampleDbContext>(options =>
    options.UseSqlServer(connectionString));

// Inyectar repositorio y servicio
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IEmployeesRepository, EmployeeRepositoy>();
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ShipperService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CustomerService>();

// Agregar controladores
builder.Services.AddControllers();

//VARIABLE PARA ACTIVAR LOS CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

//INSTANCIA PARA PERMITIR CORS DESDE UN ORIGEN
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowCredentials()
                          .AllowAnyMethod();
                          //.WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS");

                      });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.Run();
