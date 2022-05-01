using AssetManager.Shared.Options;
using Microsoft.Extensions.Configuration;
using Ory.Kratos.Client.Api;
using Ory.Kratos.Client.Client;
using Ory.Kratos.Client.Model;

namespace AssetManager.Identity;

public class OryService : IOryService
{
    private readonly V0alpha2Api _apiInstance;

    public OryService(IConfiguration configuration)
    {
        var oryConfiguration = new Configuration();
        var oryOptions = configuration.GetOptions<OryOptions>("Ory");
        oryConfiguration.BasePath = oryOptions.BaseUrl;
        oryConfiguration.AddApiKey("Authorization", oryOptions.ApiKey);

        _apiInstance = new V0alpha2Api(oryConfiguration);
    }

    public List<KratosIdentity> GetIdentities()
    {
        var result = new List<KratosIdentity>();
        try
        {
            // List Identities
            result = _apiInstance.AdminListIdentities();
            Console.WriteLine(result);
        }
        catch (ApiException e)
        {
            Console.Write("Exception when calling V0alpha2Api.AdminListIdentities: " + e.Message);
            Console.Write("Status Code: " + e.ErrorCode);
            Console.Write(e.StackTrace);
        }

        return result;
    }

    public KratosIdentity GetIdentity(string id)
    {
        var result = new KratosIdentity();
        var includeCredential = new List<string>();
        try
        {
            // List Identities
            result = _apiInstance.AdminGetIdentity(id, includeCredential);
            Console.WriteLine(result);
        }
        catch (ApiException e)
        {
            Console.Write("Exception when calling V0alpha2Api.AdminGetIdentity: " + e.Message);
            Console.Write("Status Code: " + e.ErrorCode);
            Console.Write(e.StackTrace);
        }

        return result;
    }

    public KratosIdentity CreateIdentity(KratosIdentity identity)
    {
        var kratosAdminCreateIdentityBody = new KratosAdminCreateIdentityBody(); // KratosAdminCreateIdentityBody |  (optional) 
        var result = _apiInstance.AdminCreateIdentity(kratosAdminCreateIdentityBody);
        try
        {
            // Create an Identity
            Console.WriteLine(result);
        }
        catch (ApiException  e) 
        {
            Console.Write("Exception when calling V0alpha2Api.AdminCreateIdentity: " + e.Message );
            Console.Write("Status Code: "+ e.ErrorCode);
            Console.Write(e.StackTrace);
        }
        return result;
    }

    public KratosIdentity UpdateIdentity(KratosIdentity identity)
    {
        throw new NotImplementedException();
    }

    public void DeleteIdentity(string id)
    {
        throw new NotImplementedException();
    }
}