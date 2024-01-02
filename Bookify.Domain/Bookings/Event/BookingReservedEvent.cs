using Bookify.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Domain.Bookings.Event
{
    public sealed record  BookingReservedEvent(Guid BookingId): IDomainEvent;
    
}
