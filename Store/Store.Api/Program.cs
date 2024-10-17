using Store.Domain.Repositories;
using Store.Domain.Repositories.Implementations;
using Store.Domain.Services;
using Store.Domain.Services.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependencia da camada de dominio
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IBoxRepository, BoxRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Store");
});

app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();