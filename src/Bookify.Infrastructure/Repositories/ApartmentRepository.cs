using Bookify.Domain.Apartments;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class ApartmentRepository : Repository<Apartment, ApartmentId>, IApartmentRepository
    {
        public ApartmentRepository(ApplicationDbContext context): base(context)
        {
        }
    }
}
