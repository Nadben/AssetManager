namespace AssetManager.Api;

public static class IdentityExtension
{

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer",config =>
            {
                // config.MetadataAddress = "";
                config.Authority = "https://localhost:5001/";
                config.Audience = "scope1";
            });
        // services.AddAuthorization();

        return services;
    }
    
}