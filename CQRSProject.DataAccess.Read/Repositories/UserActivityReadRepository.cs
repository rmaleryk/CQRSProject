using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSProject.Core.Entities;
using CQRSProject.Core.Extensibility.Repositories;
using CQRSProject.DataAccess.Read.Database;
using MongoDB.Driver;

namespace CQRSProject.DataAccess.Read.Repositories
{
    public class UserActivityReadRepository : IUserActivityReadRepository
    {
        private readonly ReadDbContext context;

        public UserActivityReadRepository(ReadDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<UserActivity>> GetAsync(Guid userId)
        {
            return await context.UserActivities
                .Find(activity => activity.UserId == userId.ToString())
                .ToListAsync();                
        }

        public async Task<UserActivity> GetAsync(Guid userId, DateTime date)
        {
            return (await context.UserActivities
                .Find(activity => activity.UserId == userId.ToString())
                .ToListAsync())
                .FirstOrDefault(activity => activity.Date.Date == date.Date);
        }

        public async Task<UserActivity> AddAsync(UserActivity userActivity)
        {
            await context.UserActivities.InsertOneAsync(userActivity);
            return userActivity;
        }

        public async Task<bool> UpdateAsync(string id, UserActivity userActivity)
        {
            var result = await context.UserActivities.ReplaceOneAsync(activity => activity.Id == id, userActivity);
            return result.IsAcknowledged;
        }
    }
}