using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Bookings;
using Bookify.Domain.Review;

namespace Bookify.Application.Reviews
{
    internal sealed class AddReviewCommandHandler : ICommandHandler<AddReviewCommand>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;

        public AddReviewCommandHandler(
            IReviewRepository reviewRepository, 
            IBookingRepository bookingRepository, 
            IUnitOfWork unitOfWork, 
            IDateTimeProvider dateTimeProvider)
        {
            _reviewRepository = reviewRepository;
            _bookingRepository = bookingRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<Result> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(new BookingId(request.BookingId), cancellationToken);
            if(booking is null)
            {
                return Result.Failure(BookingErrors.NotFound);
            }
            var ratingResult = Rating.Create(request.Rating);
            if(ratingResult.IsFailure)
            {
                return Result.Failure(ratingResult.Error);
            }

            var reviewResult = Review.Create(
                booking,
                ratingResult.Value,
                new Comment(request.Comment), 
                _dateTimeProvider.UtcNow);

            if (reviewResult.IsFailure)
            {
                return Result.Failure(reviewResult.Error);
            }

            _reviewRepository.Add(reviewResult.Value);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
