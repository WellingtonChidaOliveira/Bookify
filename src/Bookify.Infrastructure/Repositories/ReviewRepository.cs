using Bookify.Domain.Review;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class ReviewRepository : Repository<Review, ReviewId>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
    
}
