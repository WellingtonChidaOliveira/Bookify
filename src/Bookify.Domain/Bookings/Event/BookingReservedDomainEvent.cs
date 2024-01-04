using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Event
{
    public sealed record  BookingReservedDomainEvent(BookingId BookingId): IDomainEvent;
    
}
