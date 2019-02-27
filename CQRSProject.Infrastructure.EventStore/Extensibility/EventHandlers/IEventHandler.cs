using System.Threading.Tasks;

namespace CQRSProject.Infrastructure.EventStore.Extensibility.EventHandlers
{
    public interface IEventHandler<in TCommand>
    {
        Task HandleAsync(TCommand command);
    }
}