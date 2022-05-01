using AssetManager.Domain.Entities;
using AssetManager.Domain.Repositories;
using AssetManager.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Repositories;

public class PostgresAssetRepository : IAssetRepository
{
    private readonly AssetManagerContext _context;
    public PostgresAssetRepository(AssetManagerContext context)
    {
        _context = context;
    }

    public Task<Asset> GetAsync(AssetId id)
    {
        return _context.Assets.FirstOrDefaultAsync(x => x.Id == id)!;
    }

    public Task AddAsync(Asset asset)
    {
        _context.Assets.Add(asset);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Asset asset)
    {
        _context.Assets.Update(asset);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Asset asset)
    {
        _context.Assets.Remove(asset);
        return Task.CompletedTask;
    }
}
