namespace Bookify.Domain.Abstractions
{
    public abstract class Entity<TEntityId>
    {

        private readonly List<IDomainEvent> _domainEvents = new();
        protected Entity(TEntityId id)
        {
            Id = id;
        }

        protected Entity()
        {

        }
        public TEntityId Id { get; init; }

        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvents(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
