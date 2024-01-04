using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Event
{
    public sealed record BookingConfirmedDomainEvent(BookingId BookingId) : IDomainEvent;
}
