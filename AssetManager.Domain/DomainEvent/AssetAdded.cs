using AssetManager.Domain.Entities;

namespace AssetManager.Domain.DomainEvent
{
    public record AssetAdded(Area Area,  Asset Asset) : IDomainEvent;

}