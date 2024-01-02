namespace Bookify.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesASync(CancellationToken cancellationToken = default);
    }
}
