using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Repositories;

public interface IAreaRepository
{
    Task<Area> GetAsync(AreaId id);
    Task<IEnumerable<Area>> GetAllAsync();
    Task AddAsync(Area area);
    void UpdateAsync(Area area);
    void DeleteAsync(Area area);
}