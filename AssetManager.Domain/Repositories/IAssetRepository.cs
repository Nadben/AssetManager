using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Repositories;

public interface IAssetRepository
{
    IEnumerable<Asset> GetAssets(IEnumerable<Guid> assets);
    Task<Asset> GetAsync(AssetId id);
    Task AddAsync(Asset asset);
    Task UpdateAsync(Asset asset);
    Task DeleteAsync(Asset asset);
}