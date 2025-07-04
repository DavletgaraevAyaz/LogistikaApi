using LogistikaApi.DBContext;
using LogistikaApi.Interface;
using LogistikaApi.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestConnection")), ServiceLifetime.Scoped);

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IProductMovementService, ProductMovementService>();
builder.Services.AddScoped<IMovementTypeService, MovementTypeService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
