using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Domain.Entities;
using AssetManager.Domain.Repositories;
using AssetManager.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Infrastructure.Repositories;

public class PostgresAreaRepository : IAreaRepository
{
    private readonly AssetManagerContext _context;

    public PostgresAreaRepository(AssetManagerContext context)
    {
        _context = context;
    }

    public async Task<Area> GetAsync(AreaId id)
    {
        return await _context.Areas
            .Include(i => i.Assets)
            .Include(i => i.Owners)
            .Where(a => a.Id == id)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<Area>> GetAllAsync()
    {
        return await _context.Areas.ToListAsync();
    }

    public Task AddAsync(Area area)
    {
        _context.Areas.Add(area);
        return Task.CompletedTask;
    }

    public void UpdateAsync(Area area)
    {
        _context.Areas.Update(area);
    }

    public void DeleteAsync(Area area)
    {
        _context.Areas.Remove(area);
    }
}