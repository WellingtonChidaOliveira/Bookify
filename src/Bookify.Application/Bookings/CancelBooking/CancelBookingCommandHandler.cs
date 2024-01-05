using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;

namespace Bookify.Application.Bookings.CancelBooking
{
    internal sealed class CancelBookingCommandHandler : ICommandHandler<CancelBookingCommand>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelBookingCommandHandler(
            IUnitOfWork unitOfWork,
            IBookingRepository bookingRepository,
            IDateTimeProvider dateTimeProvider)
        {
            _unitOfWork = unitOfWork;
            _bookingRepository = bookingRepository;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(new BookingId(request.BookingId), cancellationToken);

            if (booking is null) return Result.Failure<Guid>(BookingErrors.NotFound);

            var result = booking.Cancel(_dateTimeProvider.UtcNow);
            if (result.IsFailure)
                return result;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
