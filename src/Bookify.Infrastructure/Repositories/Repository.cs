using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Repositories
{
    internal abstract class Repository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TEntityId : class
    {
        protected readonly ApplicationDbContext Context;

        protected Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetByIdAsync(TEntityId id, CancellationToken cancellationToken)
        {

            return await Context
                .Set<TEntity>()
                .FirstOrDefaultAsync(user=> user.Id == id, cancellationToken);
        }   

        public void Add(TEntity entity)
        {
            Context.Add(entity);
        }
    }
}
