using System;
using System.Threading.Tasks;
using CQRSProject.Commands.Extensibility;
using CQRSProject.Infrastructure.EventStore.Extensibility.EventHandlers;

namespace CQRSProject.Infrastructure.EventStore
{
    public class EventStore : IEventStore
    {
        private readonly IServiceProvider serviceProvider;

        public EventStore(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task StoreCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = (IEventHandler<TCommand>)serviceProvider.GetService(typeof(IEventHandler<TCommand>));

            if (handler == null)
            {
                throw new ArgumentException(nameof(ICommand));
            }

            await handler.HandleAsync(command);
        }
    }
}
