using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Application.DTO;

public class AreaDto
{
    public AreaId Id { get; set; }
    public AreaName Name { get; set; }
    public List<AssetDto> Assets { get; set; }
    public List<OwnerDto> Owners { get; set; }

    public AreaDto(AreaId id, AreaName name, List<AssetDto> assets, List<OwnerDto> owners)
    {
        Id = id;
        Name = name;
        Assets = assets;
        Owners = owners;
    }
}