using AssetManager.Domain.Entities;
using AssetManager.Domain.Factories.Interfaces;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Factories;

public class AreaFactory : IAreaFactory
{
    public Area Create(AreaName name, List<Asset> assets, List<Owner> owners) => new Area(name, assets, owners);
    
    public Area CreateEmptyArea(AreaName name) => new Area(name);
    
    public Area CreateWithDefaultValues(AreaName name, List<Asset> assets, List<Owner> owners)
    {
        var emptyArea = CreateEmptyArea(name);
        emptyArea.AddAssets(assets);
        emptyArea.AssignOwners(owners);
        return emptyArea;
    }
}