namespace Bookify.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetByIdASync(Guid id, CancellationToken cancellationToken = default);

        void Add(User user);
    }
}
