using AssetManager.Domain.Entities;

namespace AssetManager.Domain.Repositories;

public interface IRecorderRepository
{
    Task<Recorder> GetAsync(Recorder recorder);
    Task AddAsync(Recorder recorder);
    Task UpdateAsync(Recorder recorder);
    Task DeleteAsync(Recorder recorder);
}