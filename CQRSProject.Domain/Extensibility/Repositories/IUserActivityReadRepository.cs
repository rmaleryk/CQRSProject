using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSProject.Core.Entities;

namespace CQRSProject.Core.Extensibility.Repositories
{
    public interface IUserActivityReadRepository : IReadRepository<UserActivity>
    {
        Task<IEnumerable<UserActivity>> GetAsync(Guid userId);

        Task<UserActivity> GetAsync(Guid userId, DateTime date);

        Task<UserActivity> AddAsync(UserActivity userActivity);

        Task<bool> UpdateAsync(string id, UserActivity userActivity);
    }
}