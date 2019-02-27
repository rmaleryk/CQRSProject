using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSProject.Core.Entities;
using CQRSProject.Core.Extensibility.Repositories;
using CQRSProject.Queries.Extensibility;
using CQRSProject.Queries.Queries;

namespace CQRSProject.Queries.QueryHandlers
{
    public class UserActivityQueryHandler : IQueryHandler<GetUserActivityByIdQuery, IEnumerable<UserActivity>>
    {
        private readonly IUserActivityReadRepository userActivityRepository;

        public UserActivityQueryHandler(IUserActivityReadRepository userActivityRepository)
        {
            this.userActivityRepository = userActivityRepository;
        }

        public async Task<IEnumerable<UserActivity>> ExecuteAsync(GetUserActivityByIdQuery query)
        {
            return await userActivityRepository.GetAsync(query.UserId);
        }
    }
}