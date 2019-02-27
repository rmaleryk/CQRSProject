using CQRSProject.DataAccess.Write.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CQRSProject.DataAccess.Write.Extensions
{
    public static class DatabaseConfigurationExtensions
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<WriteDbContext>(options => options.UseSqlServer(connectionString, builder => builder.EnableRetryOnFailure()));
    }
}