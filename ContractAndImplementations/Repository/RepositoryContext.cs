using Entities;
using Microsoft.EntityFrameworkCore;

namespace ContractAndImplementations.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<DeviceStatusLog>? DeviceStatusLogs { get; set; }
        public DbSet<Device>? Devices { get; set; }
    }
}
