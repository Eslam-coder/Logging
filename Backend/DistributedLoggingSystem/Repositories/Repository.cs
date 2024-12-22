using DistributedLoggingSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DistributedLoggingSystemContext DbContext { get; }

        protected DbSet<T> DbSet { get; }

        public Repository(DistributedLoggingSystemContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await DbSet.ToArrayAsync();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
    }
}
