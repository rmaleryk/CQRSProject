using System.Threading;
using System.Threading.Tasks;
using CQRSProject.Core.Entities;
using CQRSProject.Core.Extensibility.Repositories;
using CQRSProject.DataAccess.Write.Database;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject.DataAccess.Write.Repositories
{
    public class UserLocationWriteRepository : IWriteRepository<UserLocation>
    {
        private readonly WriteDbContext context;
        private readonly DbSet<UserLocation> dbSet;

        public UserLocationWriteRepository(WriteDbContext context)
        {
            this.context = context;
            dbSet = context.UserLocations;
        }

        public async Task<UserLocation> SaveAsync(UserLocation userLocation, CancellationToken cancellationToken = default(CancellationToken))
        {
            await dbSet.AddAsync(userLocation, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return userLocation;
        }
    }
}