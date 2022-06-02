using AssetManager.Application;
using AssetManager.Identity;
using AssetManager.Infrastructure;
using MediatR;

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