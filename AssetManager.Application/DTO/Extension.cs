using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Application.DTO;

public static class Extension
{
    public static AssetDto ToDto(this Asset asset)
    {
        var ownerDto = new List<OwnerDto>();
        if (asset?.Owners != null)
        {
            ownerDto = asset.Owners.Select(owner => owner.ToDto()).ToList();
        }

        return new AssetDto(asset.Id,
                   asset.Name,
                   asset.IpId,
                   asset.Port,
                   asset.UserName,
                   asset.Password,
                   ownerDto)
               ?? throw new ArgumentNullException(nameof(asset));
    }

    public static AreaDto ToDto(this Area area)
    {
        var assetDto = area.Assets.Select(asset => asset.ToDto()).ToList();
        var ownerDto = area.Owners.Select(owner => owner.ToDto()).ToList();

        return new AreaDto(area.Id,
                   area.Name,
                   assetDto,
                   ownerDto)
               ?? throw new ArgumentNullException(nameof(area));
    }

    public static OwnerDto ToDto(this Owner owner)
    {
        return new OwnerDto(owner.Name, owner.Email, owner.Role) ?? throw new ArgumentNullException(nameof(owner));
    }
}