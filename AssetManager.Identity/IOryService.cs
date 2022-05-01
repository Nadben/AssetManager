using Ory.Kratos.Client.Model;

namespace AssetManager.Identity;

public interface IOryService
{
    List<KratosIdentity> GetIdentities();
    KratosIdentity GetIdentity(string id);
    KratosIdentity CreateIdentity(KratosIdentity identity);
    KratosIdentity UpdateIdentity(KratosIdentity identity);
    void DeleteIdentity(string id);
}