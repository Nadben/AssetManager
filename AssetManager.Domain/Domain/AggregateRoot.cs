using AssetManager.Domain.DomainEvent;

namespace AssetManager.Domain.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected init; }
        public IEnumerable<IDomainEvent> Event => _domainEvents;

        private readonly List<IDomainEvent> _domainEvents = new();

        protected void AddEvent(IDomainEvent @event)
        {
            _domainEvents.Add(@event);
        }

        public void ClearEvents() => _domainEvents.Clear();
    }
}