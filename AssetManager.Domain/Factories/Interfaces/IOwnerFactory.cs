using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Factories.Interfaces;

public interface IOwnerFactory
{
    Owner Create(string name, string email, RoleEnum role);
}