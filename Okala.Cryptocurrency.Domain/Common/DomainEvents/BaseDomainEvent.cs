using MediatR;

namespace Okala.Cryptocurrency.Domain.Common.DomainEvents
{
    public interface IDomainEvent : INotification
    {
        public EventLocation EventLocation { get; }
    }

    public enum EventLocation
    {
        Internal,
        External
    }
}
