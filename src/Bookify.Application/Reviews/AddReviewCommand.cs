using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Reviews
{
    public sealed record AddReviewCommand(Guid BookingId, int Rating, string Comment) : ICommand;
   
}
