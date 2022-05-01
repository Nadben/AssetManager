using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Repositories;

public interface IOwnerRepository
{
    void Add(Owner owner);
    Owner Get(string id);
    IEnumerable<Owner> GetAll();
    void Remove(Owner name);
    void Update(Owner owner);
}