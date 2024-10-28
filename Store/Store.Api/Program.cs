using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Store.Api.Configuration;
using Store.Domain.Configuration;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Implementations;
using Store.Domain.Services;
using Store.Domain.Services.Application;
using Store.Domain.Services.Infra;
using Store.Domain.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAuth();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.ConfigureSwagger();

builder.Services.AddDomain();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Store");
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization(); 

app.MapControllers();

app.Run();