using AssetManager.Domain.Entities;
using AssetManager.Domain.ValueObject;

namespace AssetManager.Domain.DomainEvent
{
    public record OwnerRemovedFromArea(Area Area, Owner Owner) : IDomainEvent;
    public record OwnerRemovedFromAsset(Asset Asset, Owner Owner) : IDomainEvent;
}