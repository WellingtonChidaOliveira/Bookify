using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;

namespace Bookify.Application.Bookings.ConfirmBooking
{
    internal sealed class ConfirmBookingCommandHandler : ICommandHandler<ConfirmBookingCommand>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConfirmBookingCommandHandler(
            IUnitOfWork unitOfWork,
            IBookingRepository bookingRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result> Handle(ConfirmBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(new BookingId(request.BookingId), cancellationToken);
            if (booking is null)
            {
                return Result.Failure(BookingErrors.NotFound);
            }

            var result = booking.Confirm(_dateTimeProvider.UtcNow);
            if (result.IsFailure)
            {
                return result;
            }
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
