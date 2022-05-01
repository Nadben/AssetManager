using AssetManager.Domain.Entities;
using AssetManager.Domain.Repositories;

namespace AssetManager.Infrastructure.Repositories;

public class PostgresRecorderRepository : IRecorderRepository
{
    private readonly AssetManagerContext _context;

    public PostgresRecorderRepository(AssetManagerContext context)
    {
        _context = context;
    }

    public Task<Recorder> GetAsync(Recorder recorder)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Recorder recorder)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Recorder recorder)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Recorder recorder)
    {
        throw new NotImplementedException();
    }
}