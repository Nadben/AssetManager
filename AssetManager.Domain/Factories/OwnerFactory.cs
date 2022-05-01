using AssetManager.Domain.Factories.Interfaces;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Factories;

public class OwnerFactory : IOwnerFactory
{
    public Owner Create(string name, string email, RoleEnum role)
    {
        return new Owner(name, email, role);
    }
}