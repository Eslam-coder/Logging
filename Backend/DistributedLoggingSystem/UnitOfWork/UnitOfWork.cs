using BuildingBlocks.UnitOfWork;
using DistributedLoggingSystem.Data;

namespace DistributedLoggingSystem.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DistributedLoggingSystemContext DbContext { get; }

        public UnitOfWork(DistributedLoggingSystemContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
