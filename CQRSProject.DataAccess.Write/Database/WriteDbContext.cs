using CQRSProject.Core.Entities;
using CQRSProject.DataAccess.Write.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.DataAccess.Write.Database
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<UserLocation> UserLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserLocationConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}