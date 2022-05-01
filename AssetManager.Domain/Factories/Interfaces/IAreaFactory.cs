using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.Factories.Interfaces;

public interface IAreaFactory
{
    Area Create(AreaName name, List<Asset> assets, List<Owner> owners);
    Area CreateEmptyArea(AreaName name);
    Area CreateWithDefaultValues(AreaName name, List<Asset> assets, List<Owner> owners);
}