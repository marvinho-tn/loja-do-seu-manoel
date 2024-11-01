using Store.Api.Configuration;
using Store.Api.Middlewares;
using Store.Application.Configuration;
using Store.Domain.Configuration;
using Store.Infra.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddAuth(builder.Configuration)
    .AddControllers()
    .Services
    .AddEndpointsApiExplorer()
    .AddStoreSwagger()
    .AddDomain()
    .AddApplication()
    .AddInfra();

var app = builder.Build();

app
    .UseSwagger()
    .UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Store");
    })
    .UseAuthentication()
    .UseAuthorization()
    .UseException()
    .UseInfra();

app.MapControllers();

app.Run();