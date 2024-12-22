using DistributedLoggingSystem.Domain;
using Microsoft.EntityFrameworkCore;

namespace DistributedLoggingSystem.Data
{
    public class DistributedLoggingSystemContext : DbContext
    {
        public DistributedLoggingSystemContext(DbContextOptions<DistributedLoggingSystemContext> options) : base(options)
        {
        }

        public DbSet<LogEntry> Logs => Set<LogEntry>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
