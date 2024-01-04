using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Event
{
    public sealed record BookingCancelledDomainEvent(BookingId BookingId): IDomainEvent;
  
}
