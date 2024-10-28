using Okala.Cryptocurrency.Domain.Common.DomainEvents;

namespace Okala.Cryptocurrency.Domain.Common
{
    public interface IAggregateRoot : IEntity
    {
        void ClearDomainEvents();
        IReadOnlyList<IDomainEvent> DomainEvents { get; }
    }
}