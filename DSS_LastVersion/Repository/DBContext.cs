using DSS_LastVersion.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS_LastVersion.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Brotherhood> Brotherhoods { get; set; }
        public DbSet<Assassin> Assassins { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Mission> Missions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
