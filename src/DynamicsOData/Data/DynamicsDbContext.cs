using DynamicsOData.Models.DynamicsEntities;
using Microsoft.EntityFrameworkCore;

namespace DynamicsOData.Data
{
    public class DynamicsDbContext : DbContext
    {
        public DynamicsDbContext(DbContextOptions<DynamicsDbContext> options)
            : base(options)
        {
        }

        public DbSet<LockEntity> LockEntities { get; set; }
        public DbSet<CustomerGroup> CustomerGroup { get; set; }
    }
}
