using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Review.Events
{
   public sealed record ReviewCreatedDomainEvent(ReviewId ReviewId): IDomainEvent;
    
}
