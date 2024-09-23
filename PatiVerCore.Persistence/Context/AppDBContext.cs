using Microsoft.EntityFrameworkCore;
using PatiVerCore.Domain.Entities;

namespace PatiVerCore.Persistence.Context
{
    public class AppDBContext : DbContext
    {
        public DbSet<LocalData> FomsLocalData { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocalData>().ToTable("FomsLocalData");
        }
    }
}
