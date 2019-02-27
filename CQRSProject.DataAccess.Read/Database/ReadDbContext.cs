using CQRSProject.Core.Entities;
using MongoDB.Driver;

namespace CQRSProject.DataAccess.Read.Database
{
    public class ReadDbContext
    {
        private readonly IMongoDatabase database;

        public ReadDbContext(IMongoDatabase database)
        {
            this.database = database;
        }

        public IMongoCollection<UserActivity> UserActivities => database.GetCollection<UserActivity>("UserActivities");
    }
}