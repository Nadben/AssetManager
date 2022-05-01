using AssetManager.Domain.Entities;

namespace AssetManager.Domain.DomainEvent
{
    public record AssetRemoved(Area Area, Asset Asset) : IDomainEvent;
}