using System;
using System.Threading.Tasks;
using CQRSProject.Commands.Commands;
using CQRSProject.Commands.Extensibility;
using CQRSProject.Core.Entities;
using CQRSProject.Core.Extensibility.Repositories;

namespace CQRSProject.Commands.CommandHandlers
{
    public class UserLocationCommandHandler : ICommandHandler<AddUserLocation>
    {
        private readonly IWriteRepository<UserLocation> repository;
        private readonly IEventStore eventStore;

        public UserLocationCommandHandler(
            IWriteRepository<UserLocation> repository,
            IEventStore eventStore)
        {
            this.repository = repository;
            this.eventStore = eventStore;
        }

        public async Task ExecuteAsync(AddUserLocation message)
        {
            var id = Guid.NewGuid();
            var date = DateTime.Now;

            var userLocation = new UserLocation(id, message.UserId, date, message.Latitude, message.Longitude, message.Height);
            await repository.SaveAsync(userLocation);

            await eventStore.StoreCommandAsync(message).ConfigureAwait(false);
        }
    }
}