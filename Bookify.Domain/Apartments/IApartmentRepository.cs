namespace Bookify.Domain.Apartments
{
    public interface IApartmentRepository
    {
        Task<Apartment?> GetByIdASync(Guid id, CancellationToken cancellationToken = default);
    }
}
