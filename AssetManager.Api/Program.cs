using AssetManager.Application;
using AssetManager.Identity;
using AssetManager.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json");

IConfiguration configuration = configurationBuilder.Build();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
builder.Services.AddOryServiceProvider();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddSwaggerGen(c =>
{
    var filePath = Path.Combine(System.AppContext.BaseDirectory, "AssetManager.Api.xml");
    c.IncludeXmlComments(filePath);
});
    
var assemblies = AppDomain.CurrentDomain.GetAssemblies();
var applicationAssembly = assemblies.First(assembly => assembly.GetName().Name == "AssetManager.Application");
var apiAssembly = assemblies.First(assembly => assembly.GetName().Name == "AssetManager.Api");

builder.Services.AddMediatR(apiAssembly, applicationAssembly);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(otpions =>
    {
        otpions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:5000",
            ValidAudience = "http://localhost:5000",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
app.Run();