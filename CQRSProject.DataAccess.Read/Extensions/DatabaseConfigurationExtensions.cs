using CQRSProject.DataAccess.Read.Database;
using MongoDB.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSProject.DataAccess.Read.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        public static void AddReadMongoDb(this IServiceCollection services, string connectionString, string databaseName)
        {
            var database = new MongoClient(connectionString).GetDatabase(databaseName);
            services.AddScoped(m => new ReadDbContext(database));
        }
    }
}