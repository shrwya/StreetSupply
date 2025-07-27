//using StreetSupply.Engines;
//using StreetSupply.Interfaces.Engines;
//using StreetSupply.Interfaces.Services;
//using StreetSupply.Services;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();
//builder.Services.AddScoped<IHawkerEngine, HawkerEngine>();
//builder.Services.AddScoped<IHawkerService, HawkerService>();


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using StreetSupply.Data;
//using StreetSupply.Interfaces.Engines;
//using StreetSupply.Interfaces.Services;
//using StreetSupply.Services;
//using StreetSupply.Engines;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "StreetSupply API",
//        Version = "v1",
//        Description = "API for StreetSupply B2B Web App"
//    });
//});

//// Add DbContext
//builder.Services.AddDbContext<StreetSupplyDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Dependency Injection
//builder.Services.AddScoped<IVendorService, VendorService>();
//builder.Services.AddScoped<IVendorEngine, VendorEngine>();

//builder.Services.AddScoped<IOrderRequestService, OrderRequestService>();
//builder.Services.AddScoped<IOrderRequestEngine, OrderRequestEngine>();
//builder.Services.AddScoped<IAuthService, AuthService>();

//// Add other services and engines as needed

//var app = builder.Build();

//// Configure the HTTP request pipeline
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StreetSupply API v1");
//        c.RoutePrefix = "swagger"; // This makes Swagger available at /swagger
//    });
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using StreetSupply.Data;
using StreetSupply.Interfaces.Services;
using StreetSupply.Services;
using StreetSupply.Engines;
using StreetSupply.Interfaces.Engines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger with JWT support
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "StreetSupply API",
        Version = "v1",
        Description = "API for StreetSupply B2B Web App"
    });

    // Add JWT to Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter: Bearer [space] your_token"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
});

// Load JWT Settings from appsettings.json
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
    };
});

// Add EF Core
builder.Services.AddDbContext<StreetSupplyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IVendorEngine, VendorEngine>();
builder.Services.AddScoped<IOrderRequestService, OrderRequestService>();
builder.Services.AddScoped<IOrderRequestEngine, OrderRequestEngine>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// HTTP Request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "StreetSupply API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Must come before Authorization
app.UseAuthorization();

app.MapControllers();

app.Run();
