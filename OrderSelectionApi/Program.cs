using OrderSelection2.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/api/categotials", (MyDbContext context) =>
{
    return context.Categotials.ToList();
});

app.MapGet("/api/clients", (MyDbContext context) =>
{
    return context.Clients.ToList();
});

app.MapGet("/api/employers", (MyDbContext context) =>
{
    return context.Employers.ToList();
});

app.MapGet("/api/orders", (MyDbContext context) =>
{
    return context.Orders.ToList();
});

app.MapGet("/api/order_status", (MyDbContext context) =>
{
    return context.OrderStatuses.ToList();
});

app.MapGet("/api/roles", (MyDbContext context) =>
{
    return context.Roles.ToList();
});

app.MapGet("/api/services", (MyDbContext context) =>
{
    return context.Services.ToList();
});

app.MapGet("/api/services_orders", (MyDbContext context) =>
{
    return context.ServicesOrders.ToList();
});

app.Run();
