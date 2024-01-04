using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Event
{
    public sealed record BookingRejectedDomainEvent(BookingId BookingId) : IDomainEvent;
}
