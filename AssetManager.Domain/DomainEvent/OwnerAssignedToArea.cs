using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.DomainEvent
{
    public record OwnerAssignedToArea(Area Area, Owner Owner) : IDomainEvent;
    public record OwnerAssignedToAsset(Asset Asset, Owner Owner) : IDomainEvent;
}