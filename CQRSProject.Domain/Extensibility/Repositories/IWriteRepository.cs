using System.Threading;
using System.Threading.Tasks;
using CQRSProject.Core.Entities;

namespace CQRSProject.Core.Extensibility.Repositories
{
    public interface IWriteRepository<T>
    {
        Task<UserLocation> SaveAsync(UserLocation userLocation, CancellationToken cancellationToken = default(CancellationToken));
    }
}