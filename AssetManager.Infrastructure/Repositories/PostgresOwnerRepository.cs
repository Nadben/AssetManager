using AssetManager.Domain.Repositories;
using AssetManager.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Repositories;

public class PostgresOwnerRepository : IOwnerRepository
{
    private readonly AssetManagerContext _context;

    public PostgresOwnerRepository(AssetManagerContext context)
    {
        _context = context;
    }

    public void Add(Owner owner)
    {
        _context.Owners.Add(owner);
    }

    public Owner Get(string name)
    {
        return _context.Owners.FirstOrDefault(i => i.Name == name);
    }

    public IEnumerable<Owner> GetAll()
    {
        return _context.Owners.ToList();
    }

    public void Remove(Owner owner)
    {
        _context.Owners.Remove(owner);
    }

    public void Update(Owner owner)
    {
        _context.Owners.Update(owner);
    }
}