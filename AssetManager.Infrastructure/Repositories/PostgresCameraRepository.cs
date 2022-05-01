using AssetManager.Domain.Entities;
using AssetManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Repositories;

public class PostgresCameraRepository : ICameraRepository
{
    private readonly AssetManagerContext _context;

    public PostgresCameraRepository(AssetManagerContext context)
    {
        _context = context;
    }

    public Task<Camera> GetAsync(Camera camera)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Camera camera)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Camera camera)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Camera camera)
    {
        throw new NotImplementedException();
    }
}