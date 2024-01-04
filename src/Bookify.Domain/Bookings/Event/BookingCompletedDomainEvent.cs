using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Event
{
    public sealed record BookingCompletedDomainEvent(BookingId BookingId): IDomainEvent;
   
}
