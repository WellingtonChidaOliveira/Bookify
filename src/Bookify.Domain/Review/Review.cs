﻿using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Review.Events;
using Bookify.Domain.Users;

namespace Bookify.Domain.Review
{
    public sealed class Review : Entity<ReviewId>
    {
        private Review(
       ReviewId id,
       ApartmentId apartmentId,
       BookingId bookingId,
       UserId userId,
       Rating rating,
       Comment comment,
       DateTime createdOnUtc)
       : base(id)
        {
            ApartmentId = apartmentId;
            BookingId = bookingId;
            UserId = userId;
            Rating = rating;
            Comment = comment;
            CreatedOnUtc = createdOnUtc;
        }
        private Review()
        {

        }

        public ApartmentId ApartmentId { get; private set; }

        public BookingId BookingId { get; private set; }

        public UserId UserId { get; private set; }

        public Rating Rating { get; private set; }

        public Comment Comment { get; private set; }

        public DateTime CreatedOnUtc { get; private set; }

        public static Result<Review> Create(
            Booking booking,
            Rating rating,
            Comment comment,
            DateTime createdOnUtc)
        {
            if (booking.Status != BookingStatus.Completed)
            {
                return Result.Failure<Review>(ReviewErrors.NotEligible);
            }

            var review = new Review(
                               ReviewId.New(),
                                booking.ApartmentId,
                                booking.Id,
                                booking.UserId,
                                rating,
                                comment,
                                createdOnUtc);
            review.RaiseDomainEvents(new ReviewCreatedDomainEvent(review.Id));

            return review;
        }

    }
}
