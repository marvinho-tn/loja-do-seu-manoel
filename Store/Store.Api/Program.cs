using Store.Api.Configuration;
using Store.Domain.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuth(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddStoreSwagger();
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