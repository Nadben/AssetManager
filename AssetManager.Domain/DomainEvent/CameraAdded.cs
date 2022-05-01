using AssetManager.Domain.Entities;

namespace AssetManager.Domain.DomainEvent
{
    public record CameraAdded(Recorder Recorder, Camera Camera) : IDomainEvent;

} 