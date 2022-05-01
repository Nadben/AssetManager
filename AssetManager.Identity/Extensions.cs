using Microsoft.Extensions.DependencyInjection;

namespace AssetManager.Identity;

public static class Extensions
{
    public static IServiceCollection AddOryServiceProvider(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IOryService, OryService>();
        return serviceCollection;
    }
}