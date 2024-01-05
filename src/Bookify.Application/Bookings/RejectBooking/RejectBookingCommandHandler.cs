﻿using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;

namespace Bookify.Application.Bookings.RejectBooking
{
    internal sealed class RejectBookingCommandHandler : ICommandHandler<RejectBookingCommand>
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RejectBookingCommandHandler(
            IDateTimeProvider dateTimeProvider,
            IBookingRepository bookingRepository,
            IUnitOfWork unitOfWork)
        {
            _dateTimeProvider = dateTimeProvider;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(RejectBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(new BookingId(request.BookingId), cancellationToken);

            if (booking is null)
            {
                return Result.Failure(BookingErrors.NotFound);
            }

            var result = booking.Reject(_dateTimeProvider.UtcNow);
            if (result.IsFailure)
                return result;

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
