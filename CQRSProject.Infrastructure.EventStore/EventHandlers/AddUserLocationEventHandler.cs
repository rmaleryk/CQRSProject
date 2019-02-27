using System;
using System.Threading.Tasks;
using CQRSProject.Commands.Commands;
using CQRSProject.Core.Entities;
using CQRSProject.Core.Extensibility.Repositories;
using CQRSProject.Infrastructure.EventStore.Extensibility.EventHandlers;

namespace CQRSProject.Infrastructure.EventStore.EventHandlers
{
    public class AddUserLocationEventHandler : IEventHandler<AddUserLocation>
    {
        private readonly IUserActivityReadRepository userActivityReadRepository;

        public AddUserLocationEventHandler(IUserActivityReadRepository userActivityReadRepository)
        {
            this.userActivityReadRepository = userActivityReadRepository;
        }

        public async Task HandleAsync(AddUserLocation addUserLocationCommand)
        {

            var activity = await userActivityReadRepository.GetAsync(addUserLocationCommand.UserId, DateTime.Now);

            if (activity == null)
            {
                await userActivityReadRepository.AddAsync(new UserActivity(
                    null,
                    addUserLocationCommand.UserId.ToString(),
                    0,
                    0,
                    DateTime.UtcNow.Date));
            }
            else
            {
                activity.Distance += 10;
                activity.Steps += 10;

                await userActivityReadRepository.UpdateAsync(activity.Id, activity);
            }
        }
    }
}