using AssetManager.Domain.Entities;

namespace AssetManager.Domain.Repositories;

public interface ICameraRepository
{
    // Repository interface for Camera entity
    Task<Camera> GetAsync(Camera camera);
    Task AddAsync(Camera camera);
    Task UpdateAsync(Camera camera);
    Task DeleteAsync(Camera camera);
}