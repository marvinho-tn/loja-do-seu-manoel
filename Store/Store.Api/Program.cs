using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Store.Domain.Repositories;
using Store.Domain.Repositories.Implementations;
using Store.Domain.Services;
using Store.Domain.Services.Application;
using Store.Domain.Services.Infra;
using Store.Domain.Utils;

var builder = WebApplication.CreateBuilder(args);

// Mapeia a seção JwtSettings do appsettings.json
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettingsSection["SecretKey"];
var issuer = jwtSettingsSection["Issuer"];
var audience = jwtSettingsSection["Audience"];

// Adiciona o serviço de autenticação JWT
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configurando o Swagger para suportar JWT
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Store API", Version = "v1" });

    // Definindo o esquema de segurança
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT desta forma: Bearer {seu token}"
    });

    // Requisitando o uso do token nas requisições protegidas
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Injeção de dependencia do Core
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IBoxRepository, BoxRepository>();

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