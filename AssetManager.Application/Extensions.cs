using AssetManager.Domain.Factories;
using AssetManager.Domain.Factories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AssetManager.Application;

public static class Extensions 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAreaFactory, AreaFactory>()
            .AddScoped<IAssetFactory, AssetFactory>()
            .AddScoped<IOwnerFactory, OwnerFactory>();

        return services;
    }
}