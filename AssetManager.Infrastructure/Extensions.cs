using AssetManager.Application.Authentication;
using AssetManager.Domain.Repositories;
using AssetManager.Infrastructure.Options;
using AssetManager.Infrastructure.Repositories;
using AssetManager.Shared.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AssetManager.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var postgresOption = configuration.GetOptions<PostgresOptions>("Postgres");
        
        services.AddDbContext<AssetManagerContext>(options =>
            options.UseNpgsql(postgresOption.connectionString));
        
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.AddTransient<IAreaRepository, PostgresAreaRepository>();
        services.AddTransient<IAssetRepository, PostgresAssetRepository>();
        services.AddTransient<ICameraRepository, PostgresCameraRepository>();
        services.AddTransient<IRecorderRepository, PostgresRecorderRepository>();
        services.AddTransient<IOwnerRepository, PostgresOwnerRepository>();
        services.AddTransient<IUserRepository, PostgresUserRepository>();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}