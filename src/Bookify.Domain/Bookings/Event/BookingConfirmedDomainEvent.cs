using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Event
{
    public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
}
